using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct
{
    public class CreateSaleProductRequestValidator : AbstractValidator<CreateSaleProductRequest>
    {
        public CreateSaleProductRequestValidator()
        {
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
