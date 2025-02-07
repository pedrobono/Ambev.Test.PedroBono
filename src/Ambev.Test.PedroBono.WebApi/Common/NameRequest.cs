﻿namespace Ambev.Test.PedroBono.WebApi.Common
{
    /// <summary>
    /// Represents a common object to use in requests in the system.
    /// </summary>
    public class NameRequest
    {
        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;
    }
}
