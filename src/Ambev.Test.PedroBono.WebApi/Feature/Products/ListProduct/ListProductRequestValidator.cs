using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.ListProduct
{

    /// <summary>
    /// Validator for ListProductRequest
    /// </summary>
    public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for ListProductRequest
        /// </summary>
        public ListProductRequestValidator()
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
