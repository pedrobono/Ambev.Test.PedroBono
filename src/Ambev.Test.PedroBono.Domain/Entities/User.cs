using Ambev.Test.PedroBono.Common.Security;
using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents a user in the system with authentication and profile information.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class User : BaseEntity, IUser
    {
        /// <summary>
        /// Gets the user's login.
        /// Must not be null, empty or have white spaces and is used as a unique identifier for authentication.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets the user's FirstName.
        /// Must not be null or empty.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the user's LastName.
        /// Must not be null or empty.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the user's email address.
        /// Must be a valid email format.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets the user's phone number.
        /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets the hashed password for authentication.
        /// Password must meet security requirements: minimum 8 characters, at least one uppercase letter,
        /// one lowercase letter, one number, and one special character.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets the user's role in the system.
        /// Determines the user's permissions and access levels.
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Gets the user's current status.
        /// Indicates whether the user is active, inactive, or blocked in the system.
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Gets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the user's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets the user's role in the system.
        /// </summary>
        /// <returns>The user's role as a string.</returns>
        string IUser.Role => Role.ToString();

        /// <summary>
        /// Gets the user's status in the system.
        /// </summary>
        /// <returns>The user's status as a string.</returns>
        string IUser.Status => Status.ToString();

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the user entity using the UserValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Username format and length</list>
        /// <list type="bullet">Email format</list>
        /// <list type="bullet">Phone number format</list>
        /// <list type="bullet">Password complexity requirements</list>
        /// <list type="bullet">Role validity</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new UserValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Activates the user account.
        /// Changes the user's status to Active.
        /// </summary>
        public void Activate()
        {
            Status = UserStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Deactivates the user account.
        /// Changes the user's status to Inactive.
        /// </summary>
        public void Deactivate()
        {
            Status = UserStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Blocks the user account.
        /// Changes the user's status to Blocked.
        /// </summary>
        public void Suspend()
        {
            Status = UserStatus.Suspended;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
