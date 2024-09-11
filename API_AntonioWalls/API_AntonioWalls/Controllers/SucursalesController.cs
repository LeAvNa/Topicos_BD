using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models;
using API_AntonioWalls.DTO;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Diagnostics;


namespace API_AntonioWalls.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {

        public readonly LinkedServerContext linkedcontext;

        public SucursalesController(LinkedServerContext context)
        {
            linkedcontext = context;
        }
        //Muestra una lista de todas las sucursales creadas en la instancia AntonioWalls
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Sucursales> sucursales = new List<Sucursales>();

            try
            {
                sucursales = linkedcontext.Sucursales.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = sucursales });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = sucursales });

            }
        }

        //Busca una sucursal por medio de su ID

        [HttpGet]
        [Route("Obtener/{idSucursal:int}")]
        public IActionResult Obtener(int idSucursal)
        {
            Sucursales sucursales = linkedcontext.Sucursales.Where(i => i.IdSucursal == idSucursal).FirstOrDefault();

            if (sucursales == null)
            {
                return BadRequest("Sucursal no encontrada");
            }
            try
            {
                sucursales = linkedcontext.Sucursales.Where(i => i.IdSucursal == idSucursal).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = sucursales });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = sucursales });
            }


        }


        //Guarda una nueva sucursal
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] SucursalesDTO newSucursal)
        {
            try
            {
                var objeto = new Sucursales()
                {
                    IdSucursal = newSucursal.IdSucursal,
                    RazSoc = newSucursal.RazSoc,
                    Calle = newSucursal.Calle,
                    Num = newSucursal.Num,
                    Col = newSucursal.Col,
                    Ciudad = newSucursal.Ciudad,
                    Estado = newSucursal.Estado,
                    Pais = newSucursal.Pais,
                    Cp = newSucursal.Cp,
                    Presup = newSucursal.Presup,
                    TelefonoSuc = newSucursal.TelefonoSuc,
                    Rfc = newSucursal.Rfc,
                    Correo = newSucursal.Correo,
                    FechaAp = newSucursal.FechaAp,
                };
                linkedcontext.Sucursales.Add(objeto);
                linkedcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] SucursalesDTO newSucursal)
        {
            Sucursales sucursales = linkedcontext.Sucursales.Find(newSucursal.IdSucursal);
            if (sucursales == null)
            {
                return BadRequest("La Sucursal no ha sido encontrada, no es posible editar");
            }

            try
            {
                sucursales.RazSoc = newSucursal.RazSoc is null ? sucursales.RazSoc : newSucursal.RazSoc;
                sucursales.Calle = newSucursal.Calle is null ? sucursales.Calle : newSucursal.Calle;
                sucursales.Num = newSucursal.Num is null ? sucursales.Num : newSucursal.Num;
                sucursales.Col = newSucursal.Col is null ? sucursales.Col : newSucursal.Col;
                sucursales.Ciudad = newSucursal.Ciudad is null ? sucursales.Ciudad : newSucursal.Ciudad;
                sucursales.Estado = newSucursal.Estado is null ? sucursales.Estado : newSucursal.Estado;
                sucursales.Pais = newSucursal.Pais is null ? sucursales.Pais : newSucursal.Pais;
                sucursales.Cp = newSucursal.Cp is null ? sucursales.Cp : newSucursal.Cp;
                sucursales.Presup = newSucursal.Presup is null ? sucursales.Presup : newSucursal.Presup;
                sucursales.TelefonoSuc = newSucursal.TelefonoSuc is null ? sucursales.TelefonoSuc : newSucursal.TelefonoSuc;
                sucursales.Correo = newSucursal.Correo is null ? sucursales.Correo : newSucursal.Correo;
                sucursales.FechaAp = newSucursal.FechaAp is null ? sucursales.FechaAp : newSucursal.FechaAp;


                linkedcontext.Sucursales.Update(sucursales);
                linkedcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new {mensaje = "ok"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int idSucursal)
        {
            Sucursales sucursales = linkedcontext.Sucursales.Find(idSucursal);

            if (sucursales == null)
            {
                return BadRequest("Sucursal no encontrada");
            }

            try
            {
                linkedcontext.Sucursales.Remove(sucursales);
                linkedcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

    }

}
