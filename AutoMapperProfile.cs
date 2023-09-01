using AutoMapper;
using tienda_comics.Data_Entities;
using tienda_comics.Models;

namespace tienda_comics
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CatalogoEntity, CatalogoViewModel>()
            .ForMember(dest => dest.idCatalogo, opt => opt.MapFrom(src => src.Id));

            CreateMap<CatalogoViewModel, CatalogoEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.idCatalogo));

            CreateMap<ProductoEntity, ProductoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.idProducto));
            CreateMap<ProductoViewModel, ProductoEntity>()
                .ForMember(dest => dest.idProducto, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductoCreateModel, ProductoEntity>();
            CreateMap<ProductoEntity, ProductoCreateModel>();
        }
    }
}
