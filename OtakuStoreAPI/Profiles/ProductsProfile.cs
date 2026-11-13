using AutoMapper;
using OtakuStoreAPI.DTO_s;
using OtakuStoreAPI.Models;

namespace OtakuStoreAPI.Profiles;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<Product, ShopProductDto>()
            .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src =>
                src.ImagesUrls == null || src.ImagesUrls.Count == 0
                    ? null
                    : src.ImagesUrls[0]));
        CreateMap<Product, ProductDetailsDto>();
    }
}