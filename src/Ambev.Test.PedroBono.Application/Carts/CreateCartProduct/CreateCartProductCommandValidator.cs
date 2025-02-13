using FluentValidation;

namespace Ambev.Test.PedroBono.Application.Carts.CreateCartProduct
{
    /// <summary>
    /// Validator for <see cref="CreateCartProductCommand"/> that defines validation rules 
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
    public class CreateCartProductCommandValidator : AbstractValidator<CreateCartProductCommand>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartProductCommandValidator"/> with defined validation rules.
        /// </summary>
        public CreateCartProductCommandValidator()
        {
            /// <summary>
            /// Validates that the ProductId is not empty.
            /// </summary>
            RuleFor(product => product.ProductId)
                .NotEmpty().WithMessage("Product Id cannot be blank");

            /// <summary>
            /// Validates that the Quantity is not empty.
            /// </summary>
            RuleFor(product => product.Quantity)
                .NotEmpty().WithMessage("Quantity cannot be blank");
        }
    }
}
