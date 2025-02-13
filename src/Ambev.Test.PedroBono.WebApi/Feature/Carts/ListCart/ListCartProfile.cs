using Ambev.Test.PedroBono.Application.Carts.ListCart;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Carts.GetCart;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.ListCart
{
    /// <summary>
    /// Profile for mapping between Application and API cart responses
    /// </summary>
    public class ListCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListCart feature
        /// </summary>
        public ListCartProfile()
        {
            CreateMap<ListCartRequest, ListCartCommand>();

            CreateMap<ListCartResult, PaginatedResponse<GetCartResponse>>();
        }
    }
}
