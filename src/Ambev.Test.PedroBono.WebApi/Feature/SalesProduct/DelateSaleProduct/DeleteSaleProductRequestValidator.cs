using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.DelateSaleProduct
{
    public class DeleteSaleProductRequestValidator : AbstractValidator<DeleteSaleProductRequest>
    {
        public DeleteSaleProductRequestValidator()
        {
            RuleFor(x => x.SaleProductId)
                .GreaterThan(0)
                .WithMessage("SaleProduct ID must be greater than 0.");

            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");
        }
    }
}
