using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models_Instancia1;
using API_AntonioWalls.DTOsucursal1;
using Microsoft.AspNetCore.Cors;
using AutoMapper;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteInstancia1 : ControllerBase
    {
        public readonly Sucursal1Context sucursal1Context;
        public readonly IMapper _mapper;

        public ClienteInstancia1(Sucursal1Context context, IMapper mapper)
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
                var clienteInstancia1s = sucursal1Context.Clientes.ToList();
                List<DTOCliente> clienteDtos = null;

                try
                {
                    clienteDtos = _mapper.Map<List<DTOCliente>>(clienteInstancia1s);
                }
                catch (AutoMapperMappingException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOCliente>() });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = clienteDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOCliente>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idCliente:int}")]
        public IActionResult Obtener (int idCliente)
        {
            try
            {


                var cliente = sucursal1Context.Clientes.Where(i => i.IdCliente == idCliente).FirstOrDefault();

                if (cliente == null)
                {
                    return BadRequest("Cliente no encontrado");
                }

                var dtoCliente = _mapper.Map<DTOCliente>(cliente);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoCliente });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOCliente newCliente)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(newCliente);

                sucursal1Context.Clientes.Add(cliente);
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
        public IActionResult Editar([FromBody] DTOCliente newCliente)
        {
            var cliente = sucursal1Context.Clientes.Find(newCliente.IdCliente);
            if (cliente == null)
            {
                return BadRequest("El cliente no ha sido encontrado, no es posible editar");
            }

            try
            {
                // Solo actualiza los campos que no sean nulos
                _mapper.Map(newCliente, cliente);

                sucursal1Context.Clientes.Update(cliente);
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
        public IActionResult Eliminar (int idCliente)
        {
            var cliente = sucursal1Context.Clientes.Find(idCliente);

            if(cliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {
                sucursal1Context.Clientes.Remove(cliente);
                sucursal1Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {mensaje = ex.Message });
            }
        }
        
    }
}
