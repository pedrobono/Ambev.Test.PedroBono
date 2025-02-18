using Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID is required.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID is required.");
            RuleFor(x => x.Products).NotEmpty().WithMessage("At least one product must be included in the sale.");
            RuleFor(p => p.Products)
            .Must(HaveUniqueIds).WithMessage("The list of items contains duplicate Products.");
        }

        private bool HaveUniqueIds(List<CreateSaleProductCommand> products)
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
