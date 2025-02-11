using Ambev.Test.PedroBono.Application.Products.GetProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.GetProduct
{
    /// <summary>
    /// Profile for mapping between Application and API rating responses
    /// </summary>
    public class GetProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct feature
        /// </summary>
        public GetProductProfile()
        {
            CreateMap<GetProductRequest, GetProductCommand>();
            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
