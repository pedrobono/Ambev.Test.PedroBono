using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Auth
{
    /// <summary>
    /// Command for authenticating a user in the system.
    /// Implements IRequest for mediator pattern handling.
    /// </summary>
    public class AuthenticateUserCommand : IRequest<AuthenticateUserResult>
    {
        /// <summary>
        /// Gets or sets the email address or username for authentication.
        /// Used as the primary identifier for the user.
        /// </summary>
        public string EmailUsername { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for authentication.
        /// Will be verified against the stored hashed password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
