namespace Ambev.Test.PedroBono.WebApi.Feature.Auth.AuthUserFeature
{
    /// <summary>
    /// Represents the response returned after user authentication
    /// </summary>
    public sealed class AuthenticateUserResponse
    {
        /// <summary>
        /// Gets or sets the JWT token for authenticated user
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
