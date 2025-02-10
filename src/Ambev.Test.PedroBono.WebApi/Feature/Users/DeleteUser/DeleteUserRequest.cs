namespace Ambev.Test.PedroBono.WebApi.Feature.Users.DeleteUser
{
    /// <summary>
    /// Request model for Deleteting a user by ID
    /// </summary>
    public class DeleteUserRequest
    {
        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public int Id { get; set; }
    }
}
