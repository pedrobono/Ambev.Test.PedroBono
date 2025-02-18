using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Sales.ListSale
{
    /// <summary>
    /// Validator for ListSaleCommand
    /// </summary>
    public class ListSaleCommandValidator : AbstractValidator<ListSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListSaleCommand
        /// </summary>
        public ListSaleCommandValidator()
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
        }
    }
}