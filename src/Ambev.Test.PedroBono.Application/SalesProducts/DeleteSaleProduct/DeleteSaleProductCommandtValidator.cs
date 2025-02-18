using FluentValidation;

namespace Ambev.Test.PedroBono.Application.SalesProducts.DeleteSaleProduct
{
    public class DeleteSaleProductCommandValidator : AbstractValidator<DeleteSaleProductCommand>
    {
        public DeleteSaleProductCommandValidator()
        {
            RuleFor(x => x.SaleProductId)
                .GreaterThan(0)
                .WithMessage("SaleProduct ID must be greater than 0.");

            RuleFor(x => x.SaleProductId)
                .GreaterThan(0)
                .WithMessage("SaleProduct ID must be greater than 0.");
        }
    }
}
