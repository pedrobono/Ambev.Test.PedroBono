using Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct
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
            CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>()
                .ForMember(command => command.SaleId, opt => opt.MapFrom(request => request.SaleId));

            CreateMap<CreateSaleProductResult, CreateSaleProductResponse>();
        }
    }
}
