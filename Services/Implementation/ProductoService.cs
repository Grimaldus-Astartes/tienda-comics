using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
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

        public async Task<ProductoViewModel> DeleteProducto(int idProducto)
        {
            var producto = await _dbContextService.Productos.FindAsync(idProducto);
            if (producto == null)
            {
                throw new Exception("El producto que desea eliminar no exite");
            }
             _dbContextService.Productos.Remove(producto);
            _dbContextService.SaveChanges();

            return _mapper.Map<ProductoViewModel>(producto);
        }

        public async Task<ProductoEntity> UpdateProducto
            (int id, ProductoUpdateModel productoModificado)
        {
            var existingProducto = await _dbContextService.Productos.FindAsync (id);
            if (existingProducto == null)
            {
                throw new Exception("No se encontro el producto");
            }
            _mapper.Map(productoModificado, existingProducto);
            var resultado = _dbContextService.Productos.Update(existingProducto);
            await _dbContextService.SaveChangesAsync();

            return resultado.Entity;
        }
    }

}
