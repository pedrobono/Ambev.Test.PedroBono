﻿using MediatR;

namespace Ambev.Test.PedroBono.Application.Products.CreateProduct
{
    /// <summary>
    /// Command for creating a new product.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating an product, 
    /// including city, street, number, zipcode, latitude, longitude, and optionally 
    /// a user ID to associate the product with a specific user. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="CreateProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        /// <summary>
        /// Gets or sets the name or title of the product.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the price of the product, represented as a decimal.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the product.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the category or type the product belongs to.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the image of the product as a byte array.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string Image { get; set; }

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
