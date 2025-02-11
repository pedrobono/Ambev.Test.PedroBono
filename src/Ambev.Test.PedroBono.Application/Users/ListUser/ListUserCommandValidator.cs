using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Users.ListUser
{
    /// <summary>
    /// Validator for ListUserCommand
    /// </summary>
    public class ListUserCommandValidator : AbstractValidator<ListUserCommand>
    {
        /// <summary>
        /// Initializes validation rules for ListUserCommand
        /// </summary>
        public ListUserCommandValidator()
        {
            RuleFor(x => x.Order)
                .NotNull().NotEmpty()
                .WithMessage("Order is required (e.g.,\"username asc, email desc\") 2 words only").Custom((order, context) =>
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