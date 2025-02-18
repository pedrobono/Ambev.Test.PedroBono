using FluentValidation;

namespace Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct
{
    public class UpdateSaleProductCommandValidator : AbstractValidator<UpdateSaleProductCommand>
    {
        public UpdateSaleProductCommandValidator()
        {
            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");

            RuleFor(x => x.SaleProductId)
                .GreaterThan(0)
                .WithMessage("SaleProductRelationship ID must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("Product ID must be greater than 0.");

            RuleFor(x => x.Qty)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.")
                .LessThan(21).WithMessage("Quantity must not be greater then 20"); ;
        }
    }
}
