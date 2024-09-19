using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AntonioWalls.Models_Instancia2;
using AutoMapper;
using API_AntonioWalls.Mappings;
using API_AntonioWalls.DTOsucursal2;

namespace API_AntonioWalls.Controllers_Instancia1
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteInstancia2 : ControllerBase
    {
        public readonly Sucursal2Context sucursal2Context;
        public readonly IMapper _mapper;

        public ClienteInstancia2(Sucursal2Context context, IMapper mapper)
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
                var clienteInstancia1s = sucursal2Context.Clientes.ToList();
                List<DTOCliente2> clienteDtos = null;

                try
                {
                    clienteDtos = _mapper.Map<List<DTOCliente2>>(clienteInstancia1s);
                }
                catch (AutoMapperMappingException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOCliente2>() });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = clienteDtos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = new List<DTOCliente2>() });
            }
        }

        [HttpGet]
        [Route("Obtener/{idCliente:int}")]
        public IActionResult Obtener (int idCliente)
        {
            try
            {


                var cliente = sucursal2Context.Clientes.Where(i => i.IdCliente == idCliente).FirstOrDefault();

                if (cliente == null)
                {
                    return BadRequest("Cliente no encontrado");
                }

                var dtoCliente = _mapper.Map<DTOCliente2>(cliente);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = dtoCliente });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] DTOCliente2 newCliente)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(newCliente);

                sucursal2Context.Clientes.Add(cliente);
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
        public IActionResult Editar([FromBody] DTOCliente2 newCliente)
        {
            var cliente = sucursal2Context.Clientes.Find(newCliente.IdCliente);
            if (cliente == null)
            {
                return BadRequest("El cliente no ha sido encontrado, no es posible editar");
            }

            try
            {
                // Solo actualiza los campos que no sean nulos
                _mapper.Map(newCliente, cliente);

                sucursal2Context.Clientes.Update(cliente);
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
        public IActionResult Eliminar (int idCliente)
        {
            var cliente = sucursal2Context.Clientes.Find(idCliente);

            if(cliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {
                sucursal2Context.Clientes.Remove(cliente);
                sucursal2Context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {mensaje = ex.Message });
            }
        }
        
    }
}
