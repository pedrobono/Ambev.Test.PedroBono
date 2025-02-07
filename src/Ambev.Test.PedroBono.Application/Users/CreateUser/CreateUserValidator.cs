using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.CreateUser
{

    /// <summary>
    /// Validator for CreateUserCommand that defines validation rules for user creation command.
    /// </summary>
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateUserCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Email: Must be in valid format (using EmailValidator)
        /// - Username: Required, must be between 3 and 50 characters
        /// - FirstName: Required, must be between 3 and 50 characters
        /// - FirstName: Required, must be between 3 and 50 characters
        /// - Password: Must meet security requirements (using PasswordValidator)
        /// - Phone: Must match international format (+X XXXXXXXXXX)
        /// - Status: Cannot be set to Unknown
        /// - Role: Cannot be set to None
        /// </remarks>
        public CreateUserCommandValidator()
        {
            RuleFor(user => user.Email).SetValidator(new EmailValidator());
            RuleFor(user => user.Username).NotEmpty().Length(3, 50);
            RuleFor(user => user.FirstName).NotEmpty().Length(3, 50);
            RuleFor(user => user.LastName).NotEmpty().Length(3, 50);
            RuleFor(user => user.Password).SetValidator(new PasswordValidator());
            RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
            RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
            RuleFor(user => user.Role).NotEqual(UserRole.None);
        }
    }
}
