using API_AntonioWalls.Models_Instancia1;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_AntonioWalls.DTOsucursal1;
using AutoMapper;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;
        public readonly IMapper _mapper;

        public EmpleadoInstancia1(Sucursal1Context context, IMapper mapper)
        {
            sucursal1Context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                var empleadoInstancia1s = sucursal1Context.Empleados.ToList();
                List<DTOEmpleado> empleadoDtos = null;

                try
                {
                    empleadoDtos = _mapper.Map<List<DTOEmpleado>>(empleadoInstancia1s);
                }
                catch (AutoMapperMappingException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOEmpleado>() });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = empleadoDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOEmpleado>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idEmpleado:int}")]
        public IActionResult Obtener(int idEmpleado)
        {
            try
            {


                var empleado = sucursal1Context.Empleados.Where(i => i.IdEmpleado == idEmpleado).FirstOrDefault();

                if (empleado == null)
                {
                    return BadRequest("Empleado no encontrado");
                }

                var dtoEmpleado = _mapper.Map<DTOEmpleado>(empleado);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoEmpleado });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOEmpleado newEmpleado)
        {
            try
            {
                var empleado = _mapper.Map<Empleado>(newEmpleado);

                sucursal1Context.Empleados.Add(empleado);
                sucursal1Context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] DTOEmpleado newEmpleado)
        {
            var empleado = sucursal1Context.Empleados.Find(newEmpleado.IdEmpleado);
            if (empleado == null)
            {
                return BadRequest("El empleado no ha sido encontrado, no es posible editar");
            }

            try
            {
                // Solo actualiza los campos que no sean nulos
                _mapper.Map(newEmpleado, empleado);

                sucursal1Context.Empleados.Update(empleado);
                sucursal1Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int idEmpleado)
        {
            var empleado = sucursal1Context.Empleados.Find(idEmpleado);

            if (empleado == null)
            {
                return BadRequest("Empleado no encontrado");
            }

            try
            {
                sucursal1Context.Empleados.Remove(empleado);
                sucursal1Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}
