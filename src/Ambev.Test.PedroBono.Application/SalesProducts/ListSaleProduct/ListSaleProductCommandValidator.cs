using FluentValidation;

namespace Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct
{
    /// <summary>
    /// Validator for ListSaleProductCommand
    /// </summary>
    public class ListSaleProductCommandValidator : AbstractValidator<ListSaleProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListSaleProductCommand
        /// </summary>
        public ListSaleProductCommandValidator()
        {
            RuleFor(x => x.Order)
                .NotNull().NotEmpty()
                .WithMessage("Order is required (e.g.,\"Title asc, description desc\") 2 words only").Custom((order, context) =>
                {
                    var conditions = order.Split(',');

                    foreach (var condition in conditions)
                    {
                        var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");

                        if (fieldAndOrder.Length != 2)
                            context.AddFailure($"The field {fieldAndOrder[0]} does not have any order (asc or desc)");
                    }
                });

            RuleFor(x => x.Size)
                .NotNull().GreaterThan(0)
                .WithMessage("Size is required");

            RuleFor(x => x.Page)
                .NotNull().GreaterThan(0)
                .WithMessage("Page is required");

            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");
        }
    }
}