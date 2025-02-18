using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.GetSale
{
    public class GetSaleCommandValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleCommandValidator()
        {
            RuleFor(x => x.SaleId)
                .GreaterThan(0)
                .WithMessage("Sale ID must be greater than 0.");
        }
    }
}
