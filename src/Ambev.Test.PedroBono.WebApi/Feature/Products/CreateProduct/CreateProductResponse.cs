using Ambev.Test.PedroBono.WebApi.Feature.Products.CreateRating;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.CreateProduct
{
    public class CreateProductResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created Product.
        /// </summary>
        /// <value>A Id that uniquely identifies the created product in the system.</value>
        public int Id { get; set; }

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
        public CreateRatingResponse Rate { get; set; } = new CreateRatingResponse();
    }
}
