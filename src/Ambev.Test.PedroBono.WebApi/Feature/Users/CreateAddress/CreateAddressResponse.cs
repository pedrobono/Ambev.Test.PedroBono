namespace Ambev.Test.PedroBono.WebApi.Feature.Users.CreateAddress
{
    /// <summary>
    /// Represents a response from a address in the system.
    /// </summary>
    public class CreateAddressResponse
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
    }
}
