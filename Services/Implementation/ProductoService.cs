using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tienda_comics.Data_Context;
using tienda_comics.Data_Entities;
using tienda_comics.Models;

namespace tienda_comics.Services.Implementation
{
    public class ProductoService : IProductoService
    {
        private readonly TiendaComics _dbContextService;
        private readonly IMapper _mapper;

        public ProductoService(TiendaComics dbContextService, IMapper mapper)
        {
            this._dbContextService = dbContextService;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<ProductoViewModel>> GetAllProductosAsync()
        {
            return _mapper
                .Map<IEnumerable<ProductoViewModel>>(await _dbContextService.Productos.ToListAsync());
        }

        public async Task<ProductoViewModel> CreateProductoAsync(ProductoCreateModel requestModel)
        {
            var productoNew = await _dbContextService.Productos.AddAsync
                (_mapper.Map<ProductoEntity>(requestModel));
            await _dbContextService.SaveChangesAsync();

            return _mapper.Map<ProductoViewModel>(productoNew.Entity);
        }
    }

}
