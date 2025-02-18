using FluentValidation;

namespace Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct
{
    public class CreateSaleProductCommandValidator : AbstractValidator<CreateSaleProductCommand>
    {
        public CreateSaleProductCommandValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty().WithMessage("Sale ID is required.")
                .GreaterThan(0).WithMessage("Sale ID must be a positive integer.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.")
                .GreaterThan(0).WithMessage("Product ID must be a positive integer.");

            RuleFor(x => x.Qty)
                .NotEmpty().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThan(21).WithMessage("Quantity must not be greater then 20");
        }
    }
}
