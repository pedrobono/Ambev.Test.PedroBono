using Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCart;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCart
{
    /// <summary>
    /// Validator for the <see cref="CreateCartRequest"/> class.
    /// Ensures that the cart request data meets the required constraints.
    /// </summary>
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            /// <summary>
            /// Validates that the UserId is not empty.
            /// </summary>
            RuleFor(product => product.UserId)
                .NotEmpty().WithMessage("User Id cannot be blank");

            /// <summary>
            /// Validates that the Date is not empty and matches the "DD/MM/YYYY" format.
            /// </summary>
            RuleFor(product => product.Date)
                .NotEmpty().WithMessage("Date cannot be blank")
                .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("Date must be in the format DD/MM/YYYY");

            /// <summary>
            /// Validates that the list of Products is not empty.
            /// </summary>
            RuleFor(product => product.Products)
                .NotEmpty().WithMessage("Products cannot be blank");
        }
    }
}
