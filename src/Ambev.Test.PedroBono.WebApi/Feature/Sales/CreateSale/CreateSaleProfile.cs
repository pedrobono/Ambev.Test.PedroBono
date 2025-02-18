using Ambev.Test.PedroBono.Application.Sales.CreateSale;
using Ambev.Test.PedroBono.Domain.Enums;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping between Application and API sale-related requests and responses
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale feature
        /// </summary>
        public CreateSaleProfile()
        {
            // Mapping CreateSaleRequest to CreateSaleCommand
            CreateMap<CreateSaleRequest, CreateSaleCommand>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(request => request.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(request => SaleStatus.NotCancelled));

            // Mapping CreateSaleResult to CreateSaleResponse
            CreateMap<CreateSaleResult, CreateSaleResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.Name.FirstName} {src.Customer.Name.LastName}"));
        }
    }
}
