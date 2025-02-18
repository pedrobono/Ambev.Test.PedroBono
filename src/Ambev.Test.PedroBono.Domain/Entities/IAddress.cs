namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Defines the contract for an address entity, containing properties for city, street, number, zipcode, latitude, longitude, creation, and update timestamps.
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// Gets or stes the id of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the city where the address is located.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the name of the street where the address is located.
        /// </summary>
        string Street { get; set; }

        /// <summary>
        /// Gets or sets the number of the address, such as the building or house number.
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Gets or sets the postal code (zipcode) for the address.
        /// </summary>
        string Zipcode { get; set; }

        /// <summary>
        /// Gets or sets the latitude coordinate of the address.
        /// </summary>
        string? Lat { get; set; }

        /// <summary>
        /// Gets or sets the longitude coordinate of the address.
        /// </summary>
        string? Long { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the address was created.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the address was last updated. This property is optional.
        /// </summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the associated user who owns or is linked to the address.
        /// </summary>
        User User { get; set; }
    }
}