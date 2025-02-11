using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Products.GetProduct
{
    /// <summary>
    /// Validator for GetProductCommand
    /// </summary>
    public class GetProductCommandValidator : AbstractValidator<GetProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetProductCommand
        /// </summary>
        public GetProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
