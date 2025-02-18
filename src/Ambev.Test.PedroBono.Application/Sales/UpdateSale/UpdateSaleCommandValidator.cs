using Ambev.Test.PedroBono.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleCommandValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID is required.");
            RuleFor(x => x.SaleId).GreaterThan(0).WithMessage("Sale ID is required.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID is required.");
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
