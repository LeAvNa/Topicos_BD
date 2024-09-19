using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models_Instancia2;
using AutoMapper;
using API_AntonioWalls.Mappings;
using API_AntonioWalls.DTOsucursal2;

namespace API_AntonioWalls.Controllers_Instancia2
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaInstancia2 : ControllerBase
    {
        // Configuración del context y automapper
        public readonly Sucursal2Context sucursal2Context;
        private readonly IMapper _mapper;

        public CategoriaInstancia2(Sucursal2Context context, IMapper mapper)
        {
            sucursal2Context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            try
            {
                // Obtener la lista de categorías desde la base de datos
                var categorias = sucursal2Context.Categorias.ToList();

                // Mapear la lista de entidades Categoria al DTOCategoria
                var categoriaDtos = _mapper.Map<List<DTOCategoria2>>(categorias);

                // Retornar la lista mapeada al DTO
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = categoriaDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOCategoria2>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idCategoria:int}")]
        public IActionResult Obtener(int idCategoria)
        {
            try
            {
                // Buscar la entidad Categoria por Id
                var categoria = sucursal2Context.Categorias.Where(i => i.IdCat == idCategoria).FirstOrDefault();

                if (categoria == null)
                {
                    return BadRequest("Categoría no encontrada");
                }

                // Mapear la entidad Categoria al DTOCategoria usando AutoMapper
                var dtoCategoria = _mapper.Map<DTOCategoria2>(categoria);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoCategoria });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOCategoria2 newCategoria)
        {
            try
            {
                // Mapeo automático usando AutoMapper
                var categoria = _mapper.Map<Categoria>(newCategoria);

                sucursal2Context.Categorias.Add(categoria);
                sucursal2Context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] DTOCategoria2 newCategoria)
        {
            var categoria = sucursal2Context.Categorias.Find(newCategoria.IdCat);
            if (categoria == null)
            {
                return BadRequest("La Categoría no ha sido encontrada, no es posible editar");
            }

            try
            {
                // Mapeo los cambios del DTO a la entidad existente
                _mapper.Map(newCategoria, categoria);

                sucursal2Context.Categorias.Update(categoria);
                sucursal2Context.SaveChanges();
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
            var categoria = sucursal2Context.Categorias.Find(idCategoria);

            if (categoria == null)
            {
                return BadRequest("Categoría no encontrada");
            }

            try
            {
                sucursal2Context.Categorias.Remove(categoria);
                sucursal2Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}