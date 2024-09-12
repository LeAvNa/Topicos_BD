using API_AntonioWalls.Models_Instancia1;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_AntonioWalls.DTOsucursal1;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;
        
        public SucursalesInstancia1(Sucursal1Context context)
        {
            sucursal1Context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Sucursales> sucursales = new List<Sucursales>();

            try
            {
                sucursales = sucursal1Context.Sucursales.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = sucursales });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = sucursales });

            }
        }

    }
}
