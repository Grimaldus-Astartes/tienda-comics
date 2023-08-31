using tienda_comics.Models;

namespace tienda_comics.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoViewModel>> GetAllProductosAsync();
    }
}
