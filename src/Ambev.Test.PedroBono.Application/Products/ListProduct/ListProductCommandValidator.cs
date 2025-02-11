using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Products.ListProduct
{
    /// <summary>
    /// Validator for ListProductCommand
    /// </summary>
    public class ListProductCommandValidator : AbstractValidator<ListProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListProductCommand
        /// </summary>
        public ListProductCommandValidator()
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