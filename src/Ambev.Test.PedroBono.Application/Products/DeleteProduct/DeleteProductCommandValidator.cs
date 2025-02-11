using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Products.DeleteProduct
{
    /// <summary>
    /// Validator for DeleteProductCommand
    /// </summary>
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteProductCommand
        /// </summary>
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
