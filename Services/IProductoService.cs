using Microsoft.EntityFrameworkCore.ChangeTracking;
using tienda_comics.Data_Entities;
using tienda_comics.Models;

namespace tienda_comics.Services
{
    public interface IProductoService
    {
        Task<ProductoViewModel> CreateProductoAsync(ProductoCreateModel requestModel);
        Task<ProductoViewModel> DeleteProducto(int idProducto);
        Task<IEnumerable<ProductoViewModel>> GetAllProductosAsync();
    }
}
