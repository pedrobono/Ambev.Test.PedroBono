using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace Ambev.Test.PedroBono.Application.Carts.UpdateCart
{

    /// <summary>
    /// Profile for mapping between Cart entity and UpdateCartResponse
    /// </summary>
    public class UpdateCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateCart operation
        /// </summary>
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartCommand, Cart>()
                .ForMember(result => result.CartProducts, opt => opt.Ignore())
                .ForMember(result => result.Date, opt => opt.MapFrom(cart => DateTime.ParseExact(cart.Date, "dd/MM/yyyy", null, DateTimeStyles.AssumeLocal | DateTimeStyles.AdjustToUniversal)));
            CreateMap<Cart, UpdateCartResult>()
                .ForMember(result => result.Products, opt => opt.MapFrom(cart => cart.CartProducts))
                 .ForMember(result => result.Date, opt => opt.MapFrom(cart => cart.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
