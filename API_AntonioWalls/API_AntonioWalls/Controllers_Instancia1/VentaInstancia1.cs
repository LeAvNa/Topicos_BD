using API_AntonioWalls.DTOsucursal1;
using API_AntonioWalls.Models_Instancia1;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;
        private readonly IMapper _mapper;

        public VentaInstancia1(Sucursal1Context context, IMapper mapper)
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
                var VentaInstancia1s = sucursal1Context.Ventas.ToList();
                List<DTOVenta> ventaDtos = null;

                try
                {
                    ventaDtos = _mapper.Map<List<DTOVenta>>(VentaInstancia1s);
                }
                catch (AutoMapperMappingException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOVenta>() });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = ventaDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOVenta>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idVenta:int}")]
        public IActionResult Obtener(int idVenta)
        {
            try
            {


                var venta = sucursal1Context.Ventas.Where(i => i.IdVenta == idVenta).FirstOrDefault();

                if (venta == null)
                {
                    return BadRequest("Venta no encontrada");
                }

                var dtoVenta = _mapper.Map<DTOVenta>(venta);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoVenta });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOVenta newVenta)
        {
            try
            {
                var venta = _mapper.Map<Venta>(newVenta);

                sucursal1Context.Ventas.Add(venta);
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
        public IActionResult Editar([FromBody] DTOVenta newVenta)
        {
            var venta = sucursal1Context.Ventas.Find(newVenta.IdVenta);
            if (venta == null)
            {
                return BadRequest("La venta no ha sido encontrado, no es posible editar");
            }

            try
            {
                // Solo actualiza los campos que no sean nulos
                _mapper.Map(newVenta, venta);

                sucursal1Context.Ventas.Update(venta);
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
        public IActionResult Eliminar(int idVenta)
        {
            var venta = sucursal1Context.Empleados.Find(idVenta);

            if (venta == null)
            {
                return BadRequest("Venta no encontrado");
            }

            try
            {
                sucursal1Context.Empleados.Remove(venta);
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
