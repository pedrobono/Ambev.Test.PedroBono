using Ambev.Test.PedroBono.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<GetSaleRequest, GetSaleCommand>();

            CreateMap<GetSaleResult, GetSaleResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.Name.FirstName} {src.Customer.Name.LastName}"))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
