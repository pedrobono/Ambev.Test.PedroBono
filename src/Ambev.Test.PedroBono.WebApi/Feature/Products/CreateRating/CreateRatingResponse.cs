﻿namespace Ambev.Test.PedroBono.WebApi.Feature.Products.CreateRating
{
    public class CreateRatingResponse
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
