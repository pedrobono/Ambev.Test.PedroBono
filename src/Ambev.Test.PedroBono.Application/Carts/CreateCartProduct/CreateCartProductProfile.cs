using Ambev.Test.PedroBono.Application.Carts.CreateCartProduct;
using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace Ambev.Test.PedroBono.Application.CartProducts.CreateCartProduct
{
    /// <summary>
    /// Profile for mapping between CartProduct entity and CreateCartProductResponse
    /// </summary>
    public class CreateCartProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCartProduct operation
        /// </summary>
        public CreateCartProductProfile()
        {
            CreateMap<CreateCartProductCommand, CartProduct>()
                .ForMember(cart => cart.Qty, opt => opt.MapFrom(command => command.Quantity));
                
            CreateMap<CartProduct, CreateCartProductResult>()
                .ForMember(result => result.Quantity, opt => opt.MapFrom(cart => cart.Qty));
        }
    }
}
