using Ambev.Test.PedroBono.Application.Users.CreateUser;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.CreateAddress
{
    /// <summary>
    /// Command for creating a new address.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating an address, 
    /// including city, street, number, zipcode, latitude, longitude, and optionally 
    /// a user ID to associate the address with a specific user. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="CreateAddressResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateAddressCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateAddressCommand : IRequest<CreateAddressResult>
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
        /// This property will be set after the insert or update on User.
        /// </summary>
        public int? UserId { get; set; }
    }
}
