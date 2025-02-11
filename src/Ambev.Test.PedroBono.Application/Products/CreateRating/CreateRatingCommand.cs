using FluentValidation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Products.CreateRating
{
    /// <summary>
    /// Command for creating a new rating.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating an rating, 
    /// including city, street, number, zipcode, latitude, longitude, and optionally 
    /// a user ID to associate the rating with a specific user. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="CreateRatingResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateRatingCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateRatingCommand : IRequest<CreateRatingResult>
    {

        /// <summary>
        /// Gets or sets the average rating of the product, which is calculated from user reviews.
        /// </summary>
        public decimal Rate { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total number of ratings the product has received.
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
