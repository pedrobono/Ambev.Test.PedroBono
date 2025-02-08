using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Feature.Auth.AuthUserFeature
{
    /// <summary>
    /// Validator for AuthenticateUserRequest
    /// </summary>
    public class AuthenticateUserRequestValidator : AbstractValidator<AuthenticateUserRequest>
    {
        /// <summary>
        /// Initializes validation rules for AuthenticateUserRequest
        /// </summary>
        public AuthenticateUserRequestValidator()
        {
            RuleFor(x => x.EmailUsername)
                .NotEmpty()
                .WithMessage("Email/Username is required")
                .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
