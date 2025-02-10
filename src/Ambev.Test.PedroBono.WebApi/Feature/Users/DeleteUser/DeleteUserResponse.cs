using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Users.CreateAddress;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.DeleteUser
{
    /// <summary>
    /// API response model for Delete User operation
    /// </summary>
    public class DeleteUserResponse
    {

        /// <summary>
        /// Deletes or sets the unique identifier of the newly created user.
        /// </summary>
        /// <value>A Id that uniquely identifies the created user in the system.</value>
        public int Id { get; set; }

        /// <summary>
        /// Deletes or sets the username. Must be unique and contain only valid characters.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Deletes or sets the password. Must meet security requirements.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Deletes or sets the phone number in format (XX) XXXXX-XXXX.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Deletes or sets the username. Must be unique and contain only valid characters.
        /// </summary>
        public NameResponse Name { get; set; } = new NameResponse();

        /// <summary>
        /// Gets or sets the Adress.
        /// </summary>
        public CreateAddressResponse Address { get; set; } = new CreateAddressResponse();

        /// <summary>
        /// Deletes or sets the email address. Must be a valid email format.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Deletes or sets the initial status of the user account.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Deletes or sets the role assigned to the user.
        /// </summary>
        public string Role { get; set; }

    }
}
