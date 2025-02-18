using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.GetSale
{
    public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
    {
        public GetSaleRequestValidator()
        {
            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");
        }
    }
}
