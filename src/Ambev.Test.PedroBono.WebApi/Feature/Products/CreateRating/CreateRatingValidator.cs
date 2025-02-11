using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.CreateRating
{
    /// <summary>
    /// Validator for the CreateRatingRequest to ensure that the Rate property is valid.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the rate provided in the CreateRatingRequest is between 0 and 5, 
    /// inclusive. It is intended for use when creating or updating a rating for a product. 
    /// If the rate is outside the valid range, an error message will be returned indicating the 
    /// valid range for ratings.
    /// </remarks>
    public class CreateRatingValidator : AbstractValidator<CreateRatingRequest>
    {
        public CreateRatingValidator()
        {
            RuleFor(product => product.Rate)
                    .InclusiveBetween(0, 5).WithMessage("Rate must be between 0 and 5.");
        }
    }
}
