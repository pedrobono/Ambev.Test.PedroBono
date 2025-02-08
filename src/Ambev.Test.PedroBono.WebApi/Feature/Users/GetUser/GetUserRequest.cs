﻿namespace Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser
{
    /// <summary>
    /// Request model for getting a user by ID
    /// </summary>
    public class GetUserRequest
    {
        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public int Id { get; set; }
    }
}
