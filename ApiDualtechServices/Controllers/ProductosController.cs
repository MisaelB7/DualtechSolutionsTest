using ApiDualtechServices.Migrations;
using ApiDualtechServices.Models.DualtechDB;
using Microsoft.AspNetCore.Mvc;


namespace ApiDualtechServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly DualtechDBContext context; 
        public ProductosController(DualtechDBContext context) {
            this.context = context;
        }
        [HttpGet]
        [Route("getAll")]

        public IActionResult GetProductos()

        {
            try
            {
                var response = new ResponseModel();
                var productos = context.Productos.ToList();
                if (productos == null)
                {
                    response.Success = false;
                    response.Message = "No se encontraron productos.";
                    return NotFound(response);
                }
                response.Success = true;
                response.Message = "Productos encontrados.";
                response.Data = productos;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = "Error al obtener los productos.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet]
        [Route("getById/{Id}")]

        public IActionResult GetProductoById(long Id)

        {
            try
            {
                var response = new ResponseModel();
                var producto = context.Productos.FirstOrDefault(c => c.ProductoId == Id);
                if (producto == null)
                {
                    response.Success = false;
                    response.Message = $"No se encontro el producto con id:{Id}.";

                    return NotFound(response);
                }
                response.Success = true;
                response.Message = "Producto encontrado.";
                response.Data = producto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = $"No se encontro el producto con id:{Id}.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }

        }

        [HttpPost]
        [Route("create")]

        public IActionResult PostCliente(ProductosDTO producto)
        {
            try
            {
                var response = new ResponseModel();

                var productocrear = new Producto
                {
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Existencia = producto.Existencia
                };

                context.Productos.Add(productocrear);
                context.SaveChanges();

                response.Success = true;
                response.Message = "Producto creado existosamente.";
                response.Data = productocrear;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = $"No se pudo crear el producto.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut]
        [Route("update")]

        public IActionResult PutProductos(ProductosDTO producto)
        {
            try
            {
                var response = new ResponseModel();


                var productoExistente = context.Productos.FirstOrDefault(c => c.ProductoId == producto.ProductoId);

                if (productoExistente == null)
                {
                    response.Success = false;
                    response.Message = $"No existe un producto con el id: {producto.ProductoId}";
                    return Ok(response);
                }

                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
                productoExistente.Existencia = producto.Existencia;


                context.Productos.Update(productoExistente);
                context.SaveChanges();

                response.Success = true;
                response.Message = "Producto creado existosamente.";
                response.Data = productoExistente;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = $"No se pudo actualizar el producto.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }
        }

    } 
}
