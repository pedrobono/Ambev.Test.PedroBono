using Ambev.Test.PedroBono.Application.Carts.GetCart;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.GetCart
{
    /// <summary>
    /// Profile for mapping between Application and API cart responses
    /// </summary>
    public class GetCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetCart feature
        /// </summary>
        public GetCartProfile()
        {
            CreateMap<GetCartRequest, GetCartCommand>();
            CreateMap<GetCartResult, GetCartResponse>()
                .ForMember(result => result.Products, opt => opt.MapFrom(cart => cart.Products)); ;
        }
    }
}
