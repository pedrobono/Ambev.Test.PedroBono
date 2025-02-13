using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct
{
    /// <summary>
    /// Validator for the <see cref="CreateCartProductRequest"/> class.
    /// Ensures that the product data for adding to the cart meets the required constraints.
    /// </summary>
    public class CreateCartProductRequestValidator : AbstractValidator<CreateCartProductRequest>
    {
        public CreateCartProductRequestValidator()
        {
            /// <summary>
            /// Validates that the ProductId is not empty.
            /// </summary>
            RuleFor(product => product.ProductId)
                .NotEmpty().WithMessage("Product Id cannot be blank");

            /// <summary>
            /// Validates that the Quantity is not empty.
            /// </summary>
            RuleFor(product => product.Quantity)
                .NotEmpty().WithMessage("Quantity cannot be blank");
        }
    }
}
