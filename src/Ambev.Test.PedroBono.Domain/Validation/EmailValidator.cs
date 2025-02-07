using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Validation
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email)
                .NotEmpty()
                .WithMessage("The email address cannot be empty.")
                .MaximumLength(100)
                .WithMessage("The email address cannot be longer than 100 characters.")
                .Must(BeValidEmail)
                .WithMessage("The provided email address is not valid.");
        }

        private bool BeValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // More strict email validation
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }
    }
}
