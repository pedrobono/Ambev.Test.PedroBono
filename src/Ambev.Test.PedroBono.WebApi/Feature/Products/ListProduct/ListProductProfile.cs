using Ambev.Test.PedroBono.Application.Products.GetProduct;
using Ambev.Test.PedroBono.Application.Products.ListProduct;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Products.GetProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.ListProduct
{
    /// <summary>
    /// Profile for mapping between Application and API ListProduct responses
    /// </summary>
    public class ListProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct feature
        /// </summary>
        public ListProductProfile()
        {
            CreateMap<ListProductRequest, ListProductCommand>();

            CreateMap<ListProductResult, PaginatedResponse<GetProductResponse>>();


        }
    }
}
