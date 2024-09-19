using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models_Instancia1;
using API_AntonioWalls.DTOsucursal1;
using AutoMapper;


namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;
        public readonly IMapper _mapper;

        public ProductoInstancia1(Sucursal1Context context, IMapper mapper)
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
                var produductoInstancia1s = sucursal1Context.Productos.ToList();
                List<DTOProducto> produdctoDtos = null;

                try
                {
                    produdctoDtos = _mapper.Map<List<DTOProducto>>(produductoInstancia1s);
                }
                catch (AutoMapperMappingException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOProducto>() });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = produdctoDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOEmpleado>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idProducto:int}")]
        public IActionResult Obtener(int idProducto)
        {
            try
            {


                var producto = sucursal1Context.Productos.Where(i => i.IdProd == idProducto).FirstOrDefault();

                if (producto == null)
                {
                    return BadRequest("Empleado no encontrado");
                }

                var dtoProducto = _mapper.Map<DTOProducto>(producto);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOProducto newProducto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(newProducto);

                sucursal1Context.Productos.Add(producto);
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
        public IActionResult Editar([FromBody] DTOProducto newProducto)
        {
            var producto = sucursal1Context.Productos.Find(newProducto.IdProd);
            if (producto == null)
            {
                return BadRequest("El producto no ha sido encontrado, no es posible editar");
            }

            try
            {
                // Solo actualiza los campos que no sean nulos
                _mapper.Map(newProducto, producto);

                sucursal1Context.Productos.Update(producto);
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
        public IActionResult Eliminar(int idProducto)
        {
            var producto = sucursal1Context.Productos.Find(idProducto);

            if (producto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                sucursal1Context.Productos.Remove(producto);
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
