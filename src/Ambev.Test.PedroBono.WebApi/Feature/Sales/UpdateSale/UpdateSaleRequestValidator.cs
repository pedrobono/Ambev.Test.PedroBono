using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("User ID must be greater than 0.");

            RuleFor(x => x.Status)
                .Must(BeAValidStatus).WithMessage("Invalid Sale Status.")
                .NotEmpty().WithMessage("Sale Status is required.");
        }

        private bool BeAValidStatus(SaleStatus status)
        {
            return Enum.IsDefined(typeof(SaleStatus), status);
        }
    }
}
