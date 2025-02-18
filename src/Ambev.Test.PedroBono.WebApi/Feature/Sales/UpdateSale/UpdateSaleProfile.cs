using Ambev.Test.PedroBono.Application.Sales.UpdateSale;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.UpdateSale
{
    /// <summary>
    /// Profile for mapping between Application and API alter sale-related requests and responses
    /// </summary>
    public class UpdateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for AlterSale feature
        /// </summary>
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>()
                .ForMember(command => command.SaleId, opt => opt.MapFrom(request => request.SaleId))
                .ForMember(command => command.CustomerId, opt => opt.MapFrom(request => request.CustomerId))
                .ForMember(command => command.UserId, opt => opt.MapFrom(request => request.UserId));

            CreateMap<UpdateSaleResult, UpdateSaleResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.Name.FirstName} {src.Customer.Name.LastName}"));
        }
    }
}
