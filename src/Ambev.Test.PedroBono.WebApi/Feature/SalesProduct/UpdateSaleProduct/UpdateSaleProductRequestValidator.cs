using FluentValidation;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.UpdateSale;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct
{
    public class UpdateSaleProductRequestValidator : AbstractValidator<UpdateSaleProductRequest>
    {
        public UpdateSaleProductRequestValidator()
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
                .WithMessage("Quantity must be greater than 0.");
        }
    }
}
