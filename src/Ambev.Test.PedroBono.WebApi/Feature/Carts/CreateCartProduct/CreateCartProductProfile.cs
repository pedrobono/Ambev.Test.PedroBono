using Ambev.Test.PedroBono.Application.Carts.CreateCartProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct

{
    /// <summary>
    /// Profile for mapping between Application and API Cart responses
    /// </summary>
    public class CreateCartProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCart feature
        /// </summary>
        public CreateCartProductProfile()
        {
            CreateMap<CreateCartProductRequest, CreateCartProductCommand>();
            CreateMap<CreateCartProductResult, CreateCartProductResponse>();
        }
    }
}
