using Microsoft.AspNetCore.Mvc;
using tienda_comics.Models;
using tienda_comics.Services;

namespace tienda_comics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }
        [HttpGet("getAll")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            return StatusCode(200, await _productoService.GetAllProductosAsync());
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateProducto(ProductoCreateModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return StatusCode(201, await _productoService.CreateProductoAsync(requestModel));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("id");
            return StatusCode(204, await _productoService.DeleteProducto(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] ProductoUpdateModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return StatusCode(204, await _productoService.UpdateProducto(id, requestModel));
            
        }
    }
}
