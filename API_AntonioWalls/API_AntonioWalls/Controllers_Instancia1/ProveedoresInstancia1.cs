using API_AntonioWalls.DTOsucursal1;
using API_AntonioWalls.Models_Instancia1;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;
        public readonly IMapper _mapper;

        public ProveedoresInstancia1(Sucursal1Context context, IMapper mapper)
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
                var proveedoresInstancia1s = sucursal1Context.Proveedores.ToList();
                List<DTOProveedores> proveedoresDtos = null;

                try
                {
                    proveedoresDtos = _mapper.Map<List<DTOProveedores>>(proveedoresInstancia1s);
                }
                catch (AutoMapperMappingException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOProveedores>() });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = proveedoresDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOProveedores>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idProveedor:int}")]
        public IActionResult Obtener(int idProveedor)
        {
            try
            {


                var proveedor = sucursal1Context.Proveedores.Where(i => i.IdProv == idProveedor).FirstOrDefault();

                if (proveedor == null)
                {
                    return BadRequest("Proveedor no encontrado");
                }

                var dtoProveedor = _mapper.Map<DTOProveedores>(proveedor);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoProveedor });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOProveedores newProveedor)
        {
            try
            {
                var proveedor = _mapper.Map<Proveedores>(newProveedor);

                sucursal1Context.Proveedores.Add(proveedor);
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
        public IActionResult Editar([FromBody] DTOProveedores newProveedor)
        {
            var proveedor = sucursal1Context.Proveedores.Find(newProveedor.IdProv);
            if (proveedor == null)
            {
                return BadRequest("El proveedor no ha sido encontrado, no es posible editar");
            }

            try
            {
                // Solo actualiza los campos que no sean nulos
                _mapper.Map(newProveedor, proveedor);

                sucursal1Context.Proveedores.Update(proveedor);
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
        public IActionResult Eliminar(int idProveedor)
        {
            var proveedor = sucursal1Context.Proveedores.Find(idProveedor);

            if (proveedor == null)
            {
                return BadRequest("Proveedor no encontrado");
            }

            try
            {
                sucursal1Context.Proveedores.Remove(proveedor);
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
