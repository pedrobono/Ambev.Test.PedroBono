using Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct
{
    public class GetSaleProductProfile : Profile
    {
        public GetSaleProductProfile()
        {
            CreateMap<GetSaleProductRequest, GetSaleProductCommand>();

            CreateMap<GetSaleProductResult, GetSaleProductResponse>()
                .ForMember(dest => dest.ProductTitle, opt => opt.MapFrom(src => src.Product.Title));
        }
    }
}
