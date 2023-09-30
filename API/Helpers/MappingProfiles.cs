using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product,ProductToReturnDto>()
            .ForMember(d => d.ProductFactory, o => o.MapFrom(s => s.ProductFactory.Name))
            .ForMember(d => d.ProductCategory, o => o.MapFrom(s => s.ProductCategory.Name))
            .ForMember(d => d.PictureURL, o => o.MapFrom<ProductUrlResolver>());
    }
}
