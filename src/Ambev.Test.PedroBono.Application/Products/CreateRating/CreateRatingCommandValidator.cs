using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Products.CreateRating
{
    /// <summary>
    /// Validator for <see cref="CreateRatingCommand"/> that defines validation rules 
    /// for creating an rating.
    /// </summary>
    /// <remarks>
    /// This class uses FluentValidation to ensure that the fields in the rating creation 
    /// command follow specific rules for proper input. The rules include validations 
    /// for the city, street, number, zipcode, latitude, and longitude fields.
    /// 
    /// Validation rules include:
    /// - **City**: Required, must be between 3 and 100 characters.
    /// - **Street**: Required, must be between 3 and 100 characters.
    /// - **Number**: Required (cannot be null).
    /// - **Zipcode**: Required, must be between 3 and 10 characters.
    /// - **Latitude**: Optional, but if provided, it cannot exceed 13 characters.
    /// - **Longitude**: Optional, but if provided, it cannot exceed 13 characters.
    /// </remarks>
    public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRatingCommandValidator"/> with defined validation rules.
        /// </summary>
        public CreateRatingCommandValidator()
        {
            RuleFor(product => product.Rate)
                    .InclusiveBetween(0, 5).WithMessage("Rate must be between 0 and 5.");
        }
    }
}
