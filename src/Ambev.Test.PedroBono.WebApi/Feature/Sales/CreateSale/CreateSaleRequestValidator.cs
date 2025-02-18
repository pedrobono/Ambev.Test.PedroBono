using FluentValidation;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct;
using Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.")
                .GreaterThan(0).WithMessage("Customer ID must be a positive integer.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .GreaterThan(0).WithMessage("User ID must be a positive integer.");

            RuleForEach(x => x.Products)
                .SetValidator(new CreateSaleProductRequestValidator()).WithMessage("Invalid product data.");
            RuleFor(p => p.Products)
            .Must(HaveUniqueIds).WithMessage("The list of items contains duplicate Products.");
        }

        private bool HaveUniqueIds(List<CreateSaleProductRequest> products)
        {
            if (products == null)
                return true;


            var idCounts = products.GroupBy(i => i.ProductId)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key)
                                .ToList();

            return idCounts.Count == 0;

        }
    }
}
