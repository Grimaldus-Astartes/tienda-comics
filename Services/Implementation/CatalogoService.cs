using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tienda_comics.Data_Context;
using tienda_comics.Data_Entities;
using tienda_comics.Models;

namespace tienda_comics.Services.Implementation
{
    public class CatalogoService : ICatalogoService
    {
        private readonly TiendaComics _dbContextService;
        private readonly IMapper _mapperService;
        

        public CatalogoService(TiendaComics dbContextService, IMapper mapperService)
        {
            this._dbContextService = dbContextService;
            this._mapperService = mapperService;
            
        }

        public async Task<IEnumerable<CatalogoViewModel>> GetAllCatalogosAsync()
        {
            return _mapperService
                .Map<IEnumerable<CatalogoViewModel>>(await _dbContextService.Catalogos.ToListAsync());
        }
    }
}
