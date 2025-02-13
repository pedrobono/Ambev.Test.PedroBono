using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.DeleteCart
{
    /// <summary>
    /// Validator for the <see cref="DeleteCartRequest"/> class.
    /// Ensures that the cart request data meets the required constraints.
    /// </summary>
    public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
    {
        public DeleteCartRequestValidator()
        {
            /// <summary>
            /// Validates that the Id of the Cart is not empty.
            /// </summary>
            RuleFor(product => product.Id)
                .NotEmpty().WithMessage("Id cannot be blank");
        }
    }
}
