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
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.idCatalogo));

            CreateMap<CatalogoViewModel, CatalogoEntity>()
            .ForMember(dest => dest.idCatalogo, opt => opt.MapFrom(src => src.id));
        }
    }
}
