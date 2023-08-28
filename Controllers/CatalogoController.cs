using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tienda_comics.Models;
using tienda_comics.Services;
using tienda_comics.Services.Implementation;

namespace tienda_comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            this._catalogoService = catalogoService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<CatalogoViewModel> response = await _catalogoService.GetAllCatalogosAsync();
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }
    }
}
