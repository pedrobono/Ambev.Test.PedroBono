using Ambev.Test.PedroBono.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Validation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
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

            RuleFor(address => address.User)
                .NotNull()
                ;
        }
    }
}
