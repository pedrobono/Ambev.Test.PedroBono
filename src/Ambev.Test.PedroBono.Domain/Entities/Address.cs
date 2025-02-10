using Ambev.Test.PedroBono.Common.Security;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents an address entity with details like city, street, number, zipcode, latitude, longitude, and the associated user.
    /// </summary>
    public class Address : BaseEntity, IAddress
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
        /// Gets or sets the date and time when the address was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the address was last updated. This property is optional.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the associated user who is linked to the address.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with this address.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class and sets the <see cref="CreatedAt"/> property to the current UTC time.
        /// </summary>
        public Address()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
