using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;

namespace Ambev.Test.PedroBono.Domain.Validation
{
    public class CartProductValidator : AbstractValidator<CartProduct>
    {

        public CartProductValidator()
        {
            RuleFor(cart => cart.CartId).NotEmpty().WithMessage("Cart is required");
            RuleFor(cart => cart.ProductId).NotEmpty().WithMessage("Product is required");
            RuleFor(cart => cart.Qty).NotEmpty().WithMessage("Quantity is required");
        }
    }
}
