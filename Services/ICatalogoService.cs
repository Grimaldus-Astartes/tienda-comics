using tienda_comics.Models;

namespace tienda_comics.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable<CatalogoViewModel>> GetAllCatalogosAsync();
    }
}
