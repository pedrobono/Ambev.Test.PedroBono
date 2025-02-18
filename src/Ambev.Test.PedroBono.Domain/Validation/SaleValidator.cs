using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;


namespace Ambev.Test.PedroBono.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            // Validate that the Date property is not in the future
            RuleFor(sale => sale.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Sale date cannot be in the future.");

            // Validate that the User are not null
            RuleFor(sale => sale.User)
                .NotNull()
                .WithMessage("User must be assigned.");

            // Validate that the Customer are not null
            RuleFor(sale => sale.Customer)
                .NotNull()
                .WithMessage("Customer must be assigned.");

            // Validate that the Products is not null or empty
            RuleFor(sale => sale.Products)
                .NotNull()
                .WithMessage("Sale must have products.")
                .Must(products => products.Count > 0)
                .WithMessage("Sale must contain at least one product.");

            // Validate the Status is assigned
            RuleFor(sale => sale.Status)
                .IsInEnum()
                .WithMessage("Invalid sale status.");
        }
    }
}
