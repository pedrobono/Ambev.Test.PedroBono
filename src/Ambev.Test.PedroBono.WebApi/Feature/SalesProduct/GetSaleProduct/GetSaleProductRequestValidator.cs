using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct
{
    public class GetSaleProductRequestValidator : AbstractValidator<GetSaleProductRequest>
    {
        public GetSaleProductRequestValidator()
        {
            RuleFor(x => x.SaleProductId)
                .GreaterThan(0)
                .WithMessage("SaleProduct ID must be greater than 0.");


            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("SaleId ID must be greater than 0.");
        }
    }
}
