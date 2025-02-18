using Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct
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
            // Mapping UpdateSaleProductRequest to UpdateSaleProductCommand (or to your command model)
            CreateMap<UpdateSaleProductRequest, UpdateSaleProductCommand>()
                .ForMember(dest => dest.SaleProductId, opt => opt.MapFrom(src => src.SaleProductId));
            CreateMap<UpdateSaleProductResult, UpdateSaleProductResponse>();
        }
    }
}
