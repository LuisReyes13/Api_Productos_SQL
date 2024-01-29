using Api_Productos_Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Productos_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosContext _context;

        public ProductosController(ProductosContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult>CrearProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>>ListaProductos()
        {
            var productos = await _context.Productos.ToListAsync();

            return Ok(productos);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult>VerProducto(int Id)
        {
            Producto producto = await _context.Productos.FindAsync(Id);

            if (producto == null) 
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult>ActualizarProducto(int Id, Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(Id);

            productoExistente!.sNombre = producto.sNombre;
            productoExistente!.sDescripcion = producto.sDescripcion;
            productoExistente!.dPrecio = producto.dPrecio;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult>EliminarProducto(int Id)
        {
            var productoBorrado = await _context.Productos.FindAsync(Id);

            _context.Productos.Remove(productoBorrado);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
