﻿using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Common;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.CreateUser
{
    /// <summary>
    /// API response model for CreateUser operation
    /// </summary>
    public class CreateUserResponse
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
        /// Gets or sets the password. Must meet security requirements.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the username. Must be unique and contain only valid characters.
        /// </summary>
        public NameRequest Name { get; set; } = new NameRequest();

        /// <summary>
        /// Gets or sets the email address. Must be a valid email format.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the initial status of the user account.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the role assigned to the user.
        /// </summary>
        public string Role { get; set; }

    }
}
