using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tienda_comics.Models;
using tienda_comics.Services;
using tienda_comics.Services.Implementation;

namespace tienda_comics.Controllers
{
    [ApiController]
    [Route("api/catalogos")]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;
        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(ICatalogoService catalogoService)
        {
            this._catalogoService = catalogoService;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            /* IEnumerable<CatalogoViewModel> response = await _catalogoService.GetAllCatalogosAsync();
             _logger.LogInformation("Respuesta que debe ser enviada", response);*/
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }
    }
}
