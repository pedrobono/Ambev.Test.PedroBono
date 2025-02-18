using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct
{
    /// <summary>
    /// Profile for mapping between Application and API alter sale product-related requests and responses
    /// </summary>
    public class UpdateSaleProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateSaleProduct feature
        /// </summary>
        public UpdateSaleProductProfile()
        {
            CreateMap<UpdateSaleProductCommand, SaleProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SaleProductId));
            CreateMap<SaleProduct, UpdateSaleProductResult>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Qty))
                .ForMember(dest => dest.SaleProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Total))
                ;
        }
    }
}
