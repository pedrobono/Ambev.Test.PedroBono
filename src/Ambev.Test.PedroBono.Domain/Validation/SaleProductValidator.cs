using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;

namespace Ambev.Test.PedroBono.Domain.Validation
{
    public class SaleProductValidator : AbstractValidator<SaleProduct>
    {
        public SaleProductValidator()
        {

            // Validate that the Sale are not null
            RuleFor(sale => sale.Sale)
                .NotNull()
                .WithMessage("Sale must be assigned.");

            // Validate that the Product are not null
            RuleFor(sale => sale.Product)
                .NotNull()
                .WithMessage("Product must be assigned.");

            // Validate that the Discount is between 0 and 20 (inclusive)
            RuleFor(saleProduct => saleProduct.Discount)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(20)
                .WithMessage("Discount must be between 0 and 20.");

            // Validate that the Quantity is greater than 0
            RuleFor(saleProduct => saleProduct.Qty)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");

            // Validate that the UnitPrice is a positive decimal
            RuleFor(saleProduct => saleProduct.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be a positive number.");

            // Validate that the Total is calculated correctly: Total = Qty * UnitPrice * (1 - Discount/100)
            RuleFor(saleProduct => saleProduct.Total)
                .Equal(saleProduct => saleProduct.Qty * saleProduct.UnitPrice * (1 - saleProduct.Discount / 100))
                .WithMessage("Total must be equal to Qty * UnitPrice * (1 - Discount/100).");

            // Validate that Status is assigned and not null
            RuleFor(saleProduct => saleProduct.Status)
                .NotNull()
                .WithMessage("Status cannot be null.");
        }
    }
}
