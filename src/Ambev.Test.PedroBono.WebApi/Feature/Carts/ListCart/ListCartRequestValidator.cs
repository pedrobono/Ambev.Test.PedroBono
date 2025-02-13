using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.ListCart
{
    /// <summary>
    /// Validator for the <see cref="ListCartRequest"/> class.
    /// Ensures that the cart request data meets the required constraints.
    /// </summary>
    public class ListCartRequestValidator : AbstractValidator<ListCartRequest>
    {
        public ListCartRequestValidator()
        {
            RuleFor(x => x.Order)
                .NotNull().NotEmpty().MinimumLength(3)
                .WithMessage("Order is required (e.g.,\"username asc, email desc\")");

            RuleFor(x => x.Size)
                .NotNull().GreaterThan(0)
                .WithMessage("Size is required");

            RuleFor(x => x.Page)
                .NotNull().GreaterThan(0)
                .WithMessage("Size is required");
        }
    }
}
