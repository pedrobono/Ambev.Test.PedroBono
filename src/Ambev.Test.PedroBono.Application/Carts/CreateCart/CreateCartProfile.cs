using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace Ambev.Test.PedroBono.Application.Carts.CreateCart
{
    /// <summary>
    /// Profile for mapping between Cart entity and CreateCartResponse
    /// </summary>
    public class CreateCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCart operation
        /// </summary>
        public CreateCartProfile()
        {
            CreateMap<CreateCartCommand, Cart>()
                .ForMember(result => result.CartProducts, opt => opt.Ignore())
                .ForMember(result => result.Date, opt => opt.MapFrom(cart => DateTime.ParseExact(cart.Date, "dd/MM/yyyy", null, DateTimeStyles.AssumeLocal | DateTimeStyles.AdjustToUniversal)));
            CreateMap<Cart, CreateCartResult>()
                 .ForMember(result => result.Date, opt => opt.MapFrom(cart => cart.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(result => result.Producs, opt => opt.MapFrom(cart => cart.CartProducts));
        }
    }
}
