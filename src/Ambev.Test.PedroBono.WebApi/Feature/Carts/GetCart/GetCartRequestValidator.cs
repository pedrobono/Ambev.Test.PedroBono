using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.GetCart
{
    /// <summary>
    /// Validator for the <see cref="GetCartRequest"/> class.
    /// Ensures that the cart request data meets the required constraints.
    /// </summary>
    public class GetCartRequestValidator : AbstractValidator<GetCartRequest>
    {
        public GetCartRequestValidator()
        {
            /// <summary>
            /// Validates that the Id of the Cart is not empty.
            /// </summary>
            RuleFor(product => product.Id)
                .NotEmpty().WithMessage("Id cannot be blank");
        }
    }
}
