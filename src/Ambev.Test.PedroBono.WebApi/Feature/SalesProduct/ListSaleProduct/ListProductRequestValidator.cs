using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.SaleProducts.ListSaleProduct
{

    /// <summary>
    /// Validator for ListSaleProductRequest
    /// </summary>
    public class ListSaleProductRequestValidator : AbstractValidator<ListSaleProductRequest>
    {
        /// <summary>
        /// Initializes validation rules for ListSaleProductRequest
        /// </summary>
        public ListSaleProductRequestValidator()
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

            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");
        }
    }
}
