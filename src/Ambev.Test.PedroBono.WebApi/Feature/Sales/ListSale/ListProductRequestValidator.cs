using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.ListSale
{

    /// <summary>
    /// Validator for ListSaleRequest
    /// </summary>
    public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
    {
        /// <summary>
        /// Initializes validation rules for ListSaleRequest
        /// </summary>
        public ListSaleRequestValidator()
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
