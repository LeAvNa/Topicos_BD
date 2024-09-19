using API_AntonioWalls.Models_Instancia1;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_AntonioWalls.DTOsucursal1;
using API_AntonioWalls.DTO;
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

        //Muestra una lista de todas las sucursales creadas en la instancia AntonioWalls
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                // Mapeamos las entidades a DTOs para controlar las propiedades que se devuelven
                var sucursalesDTOs = sucursal1Context.Sucursales
                    .Select(s => new SucursalesDTO
                    {
                        IdSucursal = s.IdSucursal,
                        RazSoc = s.RazSoc,
                        Calle = s.Calle,
                        Num = s.Num,
                        Col = s.Col,
                        Ciudad = s.Ciudad,
                        Estado = s.Estado,
                        Pais = s.Pais,
                        Cp = s.Cp,
                        Presup = s.Presup,
                        TelefonoSuc = s.TelefonoSuc,
                        Rfc = s.Rfc,
                        Correo = s.Correo,
                        FechaAp = s.FechaAp
                        // Solo incluyes las propiedades que necesitas
                    })
                    .ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = sucursalesDTOs });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }

        }

        //Busca una sucursal por medio de su ID

        [HttpGet]
        [Route("Obtener/{idSucursal:int}")]
        public IActionResult Obtener(int idSucursal)
        {
            try
            {
                // Buscamos la sucursal en la base de datos
                var sucursal = sucursal1Context.Sucursales 
                    .Where(i => i.IdSucursal == idSucursal)
                    .FirstOrDefault();

                // Si no se encuentra la sucursal, devolvemos un error 404
                if (sucursal == null)
                {
                    return NotFound(new { mensaje = "Sucursal no encontrada" });
                }

                // Mapeo manual de la entidad Sucursales a SucursalesDTO
                var sucursalDTO = new SucursalesDTO
                {
                    IdSucursal = sucursal.IdSucursal,
                    RazSoc = sucursal.RazSoc,
                    Calle = sucursal.Calle,
                    Num = sucursal.Num,
                    Col = sucursal.Col,
                    Ciudad = sucursal.Ciudad,
                    Estado = sucursal.Estado,
                    Pais = sucursal.Pais,
                    Cp = sucursal.Cp,
                    Presup = sucursal.Presup,
                    TelefonoSuc = sucursal.TelefonoSuc,
                    Rfc = sucursal.Rfc,
                    Correo = sucursal.Correo,
                    FechaAp = sucursal.FechaAp
                };

                // Retornamos el DTO mapeado con un código 200 OK
                return Ok(new { mensaje = "ok", response = sucursalDTO });
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción y devolvemos un error genérico con el mensaje de la excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error en el servidor", error = ex.Message });
            }

        }


        //Guarda una nueva sucursal
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOSucursales newSucursal)
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
                sucursal1Context.Sucursales.Add(objeto);
                sucursal1Context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] DTOSucursales newSucursal)
        {
            Sucursales sucursales = sucursal1Context.Sucursales.Find(newSucursal.IdSucursal);
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


                sucursal1Context.Sucursales.Update(sucursales);
                sucursal1Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
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
            Sucursales sucursales = sucursal1Context.Sucursales.Find(idSucursal);

            if (sucursales == null)
            {
                return BadRequest("Sucursal no encontrada");
            }

            try
            {
                sucursal1Context.Sucursales.Remove(sucursales);
                sucursal1Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

    }
}
