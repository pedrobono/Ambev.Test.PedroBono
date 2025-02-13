﻿using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {

            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Title cannot be blank")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Title cannot be longer than 50 characters.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price cannot be blank");

            RuleFor(product => product.Description)
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

            RuleFor(product => product.Category)
                .MaximumLength(100).WithMessage("Category cannot be longer than 100 characters.");
        }
    }
}
