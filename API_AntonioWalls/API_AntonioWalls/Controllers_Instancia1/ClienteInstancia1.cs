using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models_Instancia1;
using API_AntonioWalls.DTOsucursal1;
using Microsoft.AspNetCore.Cors;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;

        public ClienteInstancia1(Sucursal1Context context)
        {
            sucursal1Context = context;
        }
    }
}
