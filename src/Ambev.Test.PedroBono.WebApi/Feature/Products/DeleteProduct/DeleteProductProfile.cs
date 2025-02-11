
using Ambev.Test.PedroBono.Application.Products.DeleteProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.DeleteProduct
{
    /// <summary>
    /// Profile for mapping between Application and API rating responses
    /// </summary>
    public class DeleteProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteProduct feature
        /// </summary>
        public DeleteProductProfile()
        {
            CreateMap<DeleteProductRequest, DeleteProductCommand>();
            CreateMap<DeleteProductResult, DeleteProductResponse>();
        }
    }
}
