using Ambev.Test.PedroBono.Application.Users.CreateAddress;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.CreateAddress
{
    /// <summary>
    /// Validator for <see cref="CreateAddressRequest"/> that defines validation rules 
    /// for creating an address.
    /// </summary>
    /// <remarks>
    /// This class uses FluentValidation to ensure that the fields in the address creation 
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
    public class CreateAddressValidator : AbstractValidator<CreateAddressRequest>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAddressValidator"/> with defined validation rules.
        /// </summary>
        public CreateAddressValidator()
        {
            RuleFor(address => address.City)
                .NotEmpty().WithMessage("City name cannot be blank")
                .MinimumLength(3).WithMessage("City name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("City name cannot be longer than 100 characters.")
                ;

            RuleFor(address => address.Street)
                .NotEmpty().WithMessage("Street name cannot be blank")
                .MinimumLength(3).WithMessage("Street name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Street name cannot be longer than 100 characters.")
                ;

            RuleFor(address => address.Number)
                .NotNull().WithMessage("Number cannot be blank")
                ;

            RuleFor(address => address.Zipcode)
                .NotEmpty().WithMessage("Zipcode cannot be blank")
                .MinimumLength(3).WithMessage("Zipcode must be at least 3 characters long.")
                .MaximumLength(10).WithMessage("Zipcode cannot be longer than 10 characters.")
                ;

            RuleFor(address => address.Lat)
                .MaximumLength(13).WithMessage("Latitude cannot be longer than 13 characters.")
                ;

            RuleFor(address => address.Long)
                .MaximumLength(13).WithMessage("Longitude cannot be longer than 13 characters.")
                ;
        }
    }
}
