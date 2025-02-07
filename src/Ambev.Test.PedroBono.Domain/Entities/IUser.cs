namespace Ambev.Test.PedroBono.Domain.Entities
{
    public interface IUser
    {
        /// <summary>
        /// Retrives the Id from the system.
        /// </summary>
        /// <returns>Returns the Id from user in a string format.</returns>
        public string Id { get; }

        /// <summary>
        /// Retrives the Username from the system.
        /// </summary>
        /// <returns>Returns the username used in autentication.</returns>
        public string Username { get; }

        /// <summary>
        /// Retrives the role from the system.
        /// </summary>
        /// <returns>Returns the role from user on a string format.</returns>
        public string Role { get; }
    }
}