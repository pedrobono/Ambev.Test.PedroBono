using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.CreateAddress
{
    /// <summary>
    /// Represents the result of a successfully created or retrieved address.
    /// </summary>
    /// <remarks>
    /// This class contains the details of an address, including the city, street, 
    /// number, zipcode, optional latitude and longitude, and the associated user ID.
    /// It is typically used as the return type for operations that retrieve or create 
    /// an address, such as in response to a command or query.
    /// </remarks>
    public class CreateAddressResult
    {
        /// <summary>
        /// Gets or sets the name of the city where the address is located.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the street where the address is located.
        /// </summary>
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number of the address, such as the building or house number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the postal code (zipcode) for the address.
        /// </summary>
        public string Zipcode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the latitude coordinate of the address. This property is optional.
        /// </summary>
        public string? Lat { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the longitude coordinate of the address. This property is optional.
        /// </summary>
        public string? Long { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user ID to associate the address with a specific user.
        /// </summary>
        public int UserId { get; set; }
    }
}
