﻿using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Carts.CreateCart
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {

            /// <summary>
            /// Validates that the UserId is not empty.
            /// </summary>
            RuleFor(product => product.UserId)
                .NotEmpty().WithMessage("User Id cannot be blank");

            /// <summary>
            /// Validates that the Date is not empty and matches the "DD/MM/YYYY" format.
            /// </summary>
            RuleFor(product => product.Date)
                .NotEmpty().WithMessage("Date cannot be blank")
                .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("Date must be in the format DD/MM/YYYY");

            /// <summary>
            /// Validates that the list of Products is not empty.
            /// </summary>
            RuleFor(product => product.Products)
                .NotEmpty().WithMessage("Products cannot be blank");
        }
    }
}
