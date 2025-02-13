using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace Ambev.Test.PedroBono.Application.Carts.GetCart
{
    /// <summary>
    /// AutoMapper profile for mapping between Cart and GetCartResult.
    /// </summary>
    public sealed class GetCartProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartProfile"/> class
        /// </summary>
        public GetCartProfile()
        {
            CreateMap<Cart, GetCartResult>()
                 .ForMember(result => result.Date, opt => opt.MapFrom(cart => cart.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(result => result.Products, opt => opt.MapFrom(cart => cart.CartProducts));
        }
    }
}
