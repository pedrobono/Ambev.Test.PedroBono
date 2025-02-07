using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.Domain.Validation;
using Ambev.Test.PedroBono.WebApi.Common;
using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.CreateUser
{
    /// <summary>
    /// Validator for CreateUserRequest that defines validation rules for user creation.
    /// </summary>
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Email: Must be valid format (using EmailValidator)
        /// - Username: Required, length between 3 and 50 characters
        /// - Password: Must meet security requirements (using PasswordValidator)
        /// - Phone: Must match international format (+X XXXXXXXXXX)
        /// - Status: Required, length between 6 and 9 characters
        /// - Role: Required, length between 5 and 8 characters
        /// - Name: Cannot be Empty
        /// </remarks>
        public CreateUserRequestValidator()
        {
            RuleFor(user => user.Email).SetValidator(new EmailValidator());
            RuleFor(user => user.Username).NotEmpty().Length(3, 50);
            RuleFor(user => user.Password).SetValidator(new PasswordValidator());
            RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
            RuleFor(user => user.Status).NotEmpty().Length(6, 9);
            RuleFor(user => user.Role).NotEmpty().Length(5, 8);
            RuleFor(user => user.Name).SetValidator(new NameRequestValidator());
        }
    }
}
