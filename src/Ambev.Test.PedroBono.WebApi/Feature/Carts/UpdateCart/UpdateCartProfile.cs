using Ambev.Test.PedroBono.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.UpdateCart
{
    /// <summary>
    /// Profile for mapping between Application and API cart responses
    /// </summary>
    public class UpdateCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateCart feature
        /// </summary>
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartRequest, UpdateCartCommand>()
                .ForMember(command => command.Id, opt => opt.MapFrom(cart => cart.Id));
            CreateMap<UpdateCartResult, UpdateCartResponse>();
        }
    }
}
