using Microsoft.AspNetCore.Mvc;
using tienda_comics.Services;

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
            
            return StatusCode(200, await _catalogoService.GetAllCatalogosAsync());
        }
    }
}
