


using AutoMapper;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Shared.DataTransfererObjects;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Service.MappingProfiles;

internal class ProductProfile : Profile
{

    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>().ForMember(d => d.Brand,
            o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.Type,
            o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl,
            o => o.MapFrom<ProductUrlResolver>());

        CreateMap<ProductBrand, BrandResponse>();
        CreateMap<ProductType, TypeResponse>();

    }
}
internal class ProductUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductResponse, string>
{
    public string? Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrWhiteSpace(source.PictureUrl))
        {
            return null;
           
        }
        return $"{configuration["BaseUrl"]}{source.PictureUrl}";

    }
}
