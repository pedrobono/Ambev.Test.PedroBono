using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.ListUser
{

    /// <summary>
    /// Validator for ListUserRequest
    /// </summary>
    public class ListUserRequestValidator : AbstractValidator<ListUserRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetUserRequest
        /// </summary>
        public ListUserRequestValidator()
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
