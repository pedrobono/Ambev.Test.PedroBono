using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um usuário no sistema.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Obtém o Id do usuário.
        /// </summary>
        /// <returns>O Id de usuário.</returns>
        public int Id { get; set; }

        /// <summary>
        /// Obtém o nome de usuário.
        /// </summary>
        /// <returns>O nome de usuário.</returns>
        public string Username { get; }

        /// <summary>
        /// Obtém o papel/função do usuário no sistema.
        /// </summary>
        /// <returns>O papel do usuário como uma string.</returns>
        public string Role { get; }

        /// <summary>
        /// Obtém o status do usuário no sistema.
        /// </summary>
        /// <returns>O status do usuário como uma string.</returns>
        /// 
        public string Status { get; }

        /// <summary>
        /// Gets the user's email address.
        /// Must be a valid email format and is used as a unique identifier for authentication.
        /// </summary>
        public string Email { get; }
    }
}
