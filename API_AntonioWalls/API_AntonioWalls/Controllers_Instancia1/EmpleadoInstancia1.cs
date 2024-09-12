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
    public class EmpleadoInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;

        public EmpleadoInstancia1(Sucursal1Context context)
        {
            sucursal1Context = context;
        }
    }
}
