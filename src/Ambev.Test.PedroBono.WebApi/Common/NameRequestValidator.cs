using FluentValidation;

namespace Ambev.Test.PedroBono.WebApi.Common
{
    /// <summary>
    /// Validator for CreateUserRequest that defines validation rules for user creation.
    /// </summary>
    public class NameRequestValidator : AbstractValidator<NameRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateNameRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - FirstName: Required, length between 3 and 50 characters
        /// - LastName: Required, length between 3 and 50 characters
        /// </remarks>
        public NameRequestValidator()
        {
            RuleFor(name => name.FirstName).NotEmpty().Length(3, 50);
            RuleFor(name => name.LastName).NotEmpty().Length(3, 50);
        }
    }
}
