namespace Ambev.Test.PedroBono.Domain.Entities
{
    public interface IUser
    {
        /// <summary>
        /// Retrives the role from the system.
        /// </summary>
        /// <returns>Returns the role from user on a string format.</returns>
        public string Role { get; }

        /// <summary>
        /// Retrives the status from the system.
        /// </summary>
        /// <returns>Returns the status from user on a string format.</returns>
        public string Status { get; }
    }
}