using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.Domain.Enums;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct
{
    /// <summary>
    /// Profile for mapping between Application and API sale product-related requests and responses
    /// </summary>
    public class CreateSaleProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSaleProduct feature
        /// </summary>
        public CreateSaleProductProfile()
        {
            CreateMap<CreateSaleProductCommand, SaleProduct>()
                .ForMember(saleProduct => saleProduct.Status, opt => opt.MapFrom(command => SaleProductStatus.NotCancelled));

            CreateMap<SaleProduct, CreateSaleProductResult>()
                .ForMember(result => result.SaleProductId, opt => opt.MapFrom(saleProduct => saleProduct.Id))
                .ForMember(result => result.Quantity, opt => opt.MapFrom(saleProduct => saleProduct.Qty))
                .ForMember(result => result.TotalPrice, opt => opt.MapFrom(saleProduct => saleProduct.Total))
                ;
        }
    }
}
