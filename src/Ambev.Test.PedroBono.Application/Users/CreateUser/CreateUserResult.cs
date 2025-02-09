using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Test.PedroBono.Application.Common.Name;

namespace Ambev.Test.PedroBono.Application.Users.CreateUser
{

    /// <summary>
    /// Represents the response returned after successfully creating a new user.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created user,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateUserResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created user.
        /// </summary>
        /// <value>A Id that uniquely identifies the created user in the system.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username. Must be unique and contain only valid characters.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name. Must be unique and contain only valid characters.
        /// </summary>
        public NameResult Name { get; set; } = new NameResult();

        /// <summary>
        /// Gets or sets the password. Must meet security requirements.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address. Must be a valid email format.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the initial status of the user account.
        /// </summary>
        /// <example>(enum: Active, Inactive, Suspended)</example>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the role assigned to the user.
        /// </summary>
        /// <example>(enum: Customer, Manager, Admin)</example>
        public string Role { get; set; }

    }
}
