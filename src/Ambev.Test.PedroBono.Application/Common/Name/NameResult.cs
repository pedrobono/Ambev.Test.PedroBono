using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Common.Name
{
    /// <summary>
    /// Represents a common object to use in requests in the system.
    /// </summary>
    public class NameResult
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
