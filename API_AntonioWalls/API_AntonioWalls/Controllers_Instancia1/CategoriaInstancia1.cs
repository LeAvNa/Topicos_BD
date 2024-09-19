using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models_Instancia1;
using API_AntonioWalls.DTOsucursal1;
using AutoMapper;
using API_AntonioWalls.Mappings;


namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaInstancia1 : ControllerBase
    {
        //configuración del context y automapper
        public readonly Sucursal1Context sucursal1Context;
        private readonly IMapper _mapper;

        public CategoriaInstancia1(Sucursal1Context context, IMapper mapper)
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
                // Obtener la lista de categorías desde la base de datos
                var categoriaInstancia1s = sucursal1Context.Categorias.ToList();

                // Mapear la lista de entidades Categoria al DTOCategoria
                var categoriaDtos = _mapper.Map<List<DTOCategoria>>(categoriaInstancia1s);

                // Retornar la lista mapeada al DTO
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = categoriaDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOCategoria>() });
            }
        }


        [HttpGet]
        [Route("Obtener/{idCategoria:int}")]
        public IActionResult Obtener(int idCategoria)
        {
            try
            {
                // Buscar la entidad Categoria por Id
                var categoria = sucursal1Context.Categorias.Where(i => i.IdCat == idCategoria).FirstOrDefault();

                if (categoria == null)
                {
                    return BadRequest("Categoria no encontrada");
                }

                // Mapear la entidad Categoria al DTOCategoria usando AutoMapper
                var dtoCategoria = _mapper.Map<DTOCategoria>(categoria);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoCategoria });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOCategoria newCategoria)
        {
            try
            {
                // Mapeo automático usando AutoMapper
                var categoria = _mapper.Map<Categoria>(newCategoria);

                sucursal1Context.Categorias.Add(categoria);
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
        public IActionResult Editar([FromBody] DTOCategoria newCategoria)
        {
            var categoria = sucursal1Context.Categorias.Find(newCategoria.IdCat);
            if (categoria == null)
            {
                return BadRequest("La Categoría no ha sido encontrada, no es posible editar");
            }

            try
            {
                // Mapeo los cambios del DTO a la entidad existente
                _mapper.Map(newCategoria, categoria);

                sucursal1Context.Categorias.Update(categoria);
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
        public IActionResult Eliminar(int idCategoria)
        {
            var categoria = sucursal1Context.Categorias.Find(idCategoria);

            if (categoria == null)
            {
                return BadRequest("Categoría no encontrada");
            }

            try
            {
                sucursal1Context.Categorias.Remove(categoria);
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
