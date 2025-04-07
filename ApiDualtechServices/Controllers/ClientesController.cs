using ApiDualtechServices.Models.DualtechDB;
using Microsoft.AspNetCore.Mvc;


namespace ApiDualtechServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly DualtechDBContext context; 
        public ClientesController(DualtechDBContext context) {
            this.context = context;
        }
        [HttpGet]
        [Route("getAll")]
       
        public IActionResult GetCliente()

        {
            try
            {
                var response = new ResponseModel();
                var clientes = context.Clientes.ToList();
                if (clientes == null)
                {
                    response.Success = false;
                    response.Message = "No se encontraron clientes.";
                    return NotFound(response);
                }
                response.Success = true;
                response.Message = "Clientes encontrados.";
                response.Data = clientes;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = "Error al obtener los clientes.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }   
           
        }

        [HttpGet]
        [Route("getById/{Id}")]

        public IActionResult GetClienteById(long Id)

        {
            try
            {
                var response = new ResponseModel();
                var cliente = context.Clientes.FirstOrDefault(c => c.ClienteId == Id);
                if (cliente == null)
                {
                    response.Success = false;
                    response.Message = $"No se encontro el cliente con id:{Id}.";
                    
                    return NotFound(response);
                }
                response.Success = true;
                response.Message = "Cliente encontrado.";
                response.Data = cliente;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = $"No se encontro el cliente con id:{Id}.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("create")]
        
        public IActionResult PostCliente(ClientesDTO cliente)
        {
            try
            {
                var response = new ResponseModel();

                var clientes = context.Clientes.FirstOrDefault(c => c.Identidad == cliente.Identidad);

                if (clientes != null) {
                    response.Success = false;
                    response.Message = $"Ya existe un cliente con la identidad: {cliente.Identidad}";
                    return Ok(response);
                 }

                var clientecrear = new Cliente
                {
                    Nombre = cliente.Nombre,
                    Identidad = cliente.Identidad
                };
                
                context.Clientes.Add(clientecrear);
                context.SaveChanges();

                response.Success = true;
                response.Message = "Cliente creado existosamente.";
                response.Data = clientecrear;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = $"No se pudo crear el cliente.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut]
        [Route("update")]

        public IActionResult PutCliente(ClientesDTO cliente)
        {
            try
            {
                var response = new ResponseModel();

                
                var clienteExistente = context.Clientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);

                if (clienteExistente == null)
                {
                    response.Success = false;
                    response.Message = $"No existe un cliente con el id: {cliente.ClienteId}";
                    return Ok(response);
                }

                var clientes = context.Clientes.FirstOrDefault(c => c.Identidad == cliente.Identidad && c.ClienteId != cliente.ClienteId);
                if (clientes != null)
                {
                    response.Success = false;
                    response.Message = $"Ya existe un cliente con la identidad: {cliente.Identidad}";
                    return Ok(response);
                }

                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.Identidad = cliente.Identidad;
                
                context.Clientes.Update(clienteExistente);
                context.SaveChanges();

                response.Success = true;
                response.Message = "Cliente actualizado existosamente.";
                response.Data = clienteExistente;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = $"No se pudo actualizar el cliente.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }
        }
    } 
}
