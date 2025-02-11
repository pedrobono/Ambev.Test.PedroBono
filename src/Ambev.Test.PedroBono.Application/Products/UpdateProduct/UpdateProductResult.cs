using Ambev.Test.PedroBono.Application.Products.CreateRating;

namespace Ambev.Test.PedroBono.Application.Products.UpdateProduct
{
    /// <summary>
    /// Represents the response returned after retrive a product by an ID.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an product,
    /// which can be used for subsequent operations or reference.
    /// </remarks>a
    public class UpdateProductResult
    {
        /// <summary>
        /// Updates or sets the unique identifier of an product.
        /// </summary>
        /// <value>A Id that uniquely identifies the product in the system.</value>
        public int Id { get; set; }

        /// <summary>
        /// Updates or sets the name or title of the product.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Updates or sets the price of the product, represented as a decimal.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Updates or sets a detailed description of the product.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Updates or sets the category or type the product belongs to.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Updates or sets the image of the product as a byte array.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Updates or sets the average rating of the product, which is calculated from user reviews.
        /// </summary>
        public CreateRatingResult Rate { get; set; } = new CreateRatingResult();
    }
}
