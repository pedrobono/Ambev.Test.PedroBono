using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.DeleteProduct
{
    /// <summary>
    /// Validator for the DeleteProductRequest to ensure that the Id property is valid.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the id provided in the DeleteProductRequest is not empty.
    /// It is intended for use when delete a product.
    /// </remarks>
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(product => product.Id)
                    .NotEmpty().WithMessage("Id must be not empty");
        }
    }
}
