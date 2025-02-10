using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Users.CreateAddress;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.UpdateUser
{   
    /// <summary>
    /// Represents a request to Update a new user in the system.
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly Updated user.
        /// </summary>
        /// <value>A Id that uniquely identifies the Updated user in the system.</value>
        internal int Id { get; set; }

        /// <summary>
        /// Gets or sets the username. Must be unique and contain only valid characters.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the username. Must be unique and contain only valid characters.
        /// </summary>
        public NameRequest Name { get; set; } = new NameRequest();

        /// <summary>
        /// Gets or sets the Adress.
        /// </summary>
        public CreateAddressRequest Address { get; set; } = new CreateAddressRequest();

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
