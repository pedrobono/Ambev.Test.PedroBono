using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Enums
{
    /// <summary>
    /// Enum with the possibles stats of a user
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Unknown = 0
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Active = 1
        /// </summary>
        Active = 1,

        /// <summary>
        /// Active = 2
        /// </summary>
        Inactive = 2,

        /// <summary>
        /// Active = 3
        /// </summary>
        Suspended = 3
    }
}
