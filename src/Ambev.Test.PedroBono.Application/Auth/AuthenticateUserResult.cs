﻿namespace Ambev.Test.PedroBono.Application.Auth
{
    /// <summary>
    /// Represents the response after authenticating a user
    /// </summary>
    public sealed class AuthenticateUserResult
    {
        /// <summary>
        /// Gets or sets the authentication token
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the User's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's phone number
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's role
        /// </summary>
        public string Role { get; set; } = string.Empty;
    }
}
