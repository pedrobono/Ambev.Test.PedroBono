using FluentValidation;

namespace Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct
{
    public class GetSaleProductCommandValidator : AbstractValidator<GetSaleProductCommand>
    {
        public GetSaleProductCommandValidator()
        {
            RuleFor(x => x.SaleProductId)
                .GreaterThan(0)
                .WithMessage("Sale product ID must be greater than 0.");

            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");
        }
    }
}
