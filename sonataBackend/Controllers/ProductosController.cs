using Microsoft.AspNetCore.Mvc;
using sonataBackend.Models;
using sonataBackend.Services;

namespace sonataBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController: ControllerBase
    {
        private readonly ServicioProducto _servicioProducto;

        public ProductosController(ServicioProducto servicioProducto)
        {
            _servicioProducto = servicioProducto;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _servicioProducto.ObtenerProductos();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto(Producto producto)
        {
            await _servicioProducto.AgregarProducto(producto);
            return CreatedAtAction(nameof(ObtenerProductos), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            await _servicioProducto.ActualizarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _servicioProducto.EliminarProducto(id);
            return NoContent();
        }
    }
}

