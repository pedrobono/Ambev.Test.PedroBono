using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;

namespace Ambev.Test.PedroBono.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Title cannot be blank")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Title cannot be longer than 50 characters.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price cannot be blank");

            RuleFor(product => product.Description)
                .MaximumLength(500).WithMessage("Title cannot be longer than 500 characters.");

            RuleFor(product => product.Category)
                .MaximumLength(100).WithMessage("Title cannot be longer than 500 characters.");

            RuleFor(product => product.Rate)
                .InclusiveBetween(0, 5).WithMessage("Rate must be between 0 and 5.");
        }
    }
}
