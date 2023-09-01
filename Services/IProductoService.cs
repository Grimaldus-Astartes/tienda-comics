using tienda_comics.Models;

namespace tienda_comics.Services
{
    public interface IProductoService
    {
        Task<ProductoViewModel> CreateProductoAsync(ProductoCreateModel requestModel);
        Task<IEnumerable<ProductoViewModel>> GetAllProductosAsync();
    }
}
