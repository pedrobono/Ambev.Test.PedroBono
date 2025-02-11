using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.GetProduct
{
    /// <summary>
    /// Validator for the GetProductRequest to ensure that the Id property is valid.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the id provided in the GetProductRequest is not empty.
    /// It is intended for use when delete a product.
    /// </remarks>
    public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductRequestValidator()
        {
            RuleFor(product => product.Id)
                    .NotEmpty().WithMessage("Id must be not empty");
        }
    }
}
