using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;

namespace Ambev.Test.PedroBono.Domain.Validation
{
    /// <summary>
    /// Validator class for validating a Cart object using FluentValidation.
    /// Ensures that required fields such as Date and UserId are provided.
    /// </summary>
    public class CartValidator : AbstractValidator<Cart>
    {
        /// <summary>
        /// Constructor that sets up the validation rules for the Cart object.
        /// </summary>
        public CartValidator()
        {
            RuleFor(cart => cart.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(cart => cart.UserId).NotEmpty().WithMessage("User is required");
        }
    }
}
