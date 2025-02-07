using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.CreateUser
{

    /// <summary>
    /// Represents the response returned after successfully creating a new user.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created user,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateUserResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created user.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created user in the system.</value>
        public Guid Id { get; set; }
    }
}
