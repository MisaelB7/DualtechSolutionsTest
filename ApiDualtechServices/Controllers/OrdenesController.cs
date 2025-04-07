using ApiDualtechServices.Migrations;
using ApiDualtechServices.Models.DualtechDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.Validations;


namespace ApiDualtechServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : Controller
    {
        private readonly DualtechDBContext context;
        public OrdenesController(DualtechDBContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [Route("create")]

        public IActionResult PostOrden(OrdenDTO orden)
        {
            try
            {
                var response = new ResponseModel();
                var clientes = context.Clientes.FirstOrDefault(c => c.ClienteId == orden.ClienteId);
                if (clientes == null)
                {
                    response.Success = false;
                    response.Message = $"No existe un cliente con el id: {orden.ClienteId}";
                    return Ok(response);
                }

                var OrdenACrear = new Orden
                {
                    ClienteId = orden.ClienteId,

                };

                foreach (var item in orden.Detalle)
                {
                    var producto = context.Productos.FirstOrDefault(c => c.ProductoId == item.ProductoId);
                    if (producto == null)
                    {
                        response.Success = false;
                        response.Message = $"No existe un producto con el id: {item.ProductoId}";
                        return Ok(response);
                    }
                    if (producto.Existencia < item.Cantidad)
                    {
                        response.Success = false;
                        response.Message = $"No hay suficiente existencia del producto con el id: {item.ProductoId}";
                        return Ok(response);
                    }
                    var subtotal = producto.Precio * item.Cantidad;
                    var impuesto = subtotal * 0.15m;
                    var total = subtotal + impuesto;
                    var detalleOrden = new DetalleOrden
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        Impuesto = impuesto,
                        Subtotal = subtotal,
                        Total = total
                    };

                    OrdenACrear.DetalleOrdens.Add(detalleOrden);
                    producto.Existencia -= (long)item.Cantidad;
                    context.Productos.Update(producto);
                    context.SaveChanges();
                }
                OrdenACrear.Impuesto = OrdenACrear.DetalleOrdens.Sum(x => x.Impuesto);
                OrdenACrear.Subtotal = OrdenACrear.DetalleOrdens.Sum(x => x.Subtotal);
                OrdenACrear.Total = OrdenACrear.DetalleOrdens.Sum(x => x.Total);
                

                context.Ordens.Add(OrdenACrear);
                context.SaveChanges();
                response.Success = true;
                response.Message = "Orden creada correctamente.";
                response.Data = orden;
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel();
                response.Success = false;
                response.Message = "Error al crear la orden.";
                response.Errors.Add(ex.Message);
                return StatusCode(500, response);
            }
        }
    }
