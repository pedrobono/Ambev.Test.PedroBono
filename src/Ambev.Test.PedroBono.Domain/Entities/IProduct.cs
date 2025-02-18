namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Defines the contract for a Product entity.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets or stes the id of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the product.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the product.
        /// </summary>
        string? Description { get; set; }

        /// <summary>
        /// Gets or sets the category or type the product belongs to.
        /// </summary>
        string? Category { get; set; }

        /// <summary>
        /// Gets or sets the image of the product as a byte array.
        /// </summary>
        string Image { get; set; }

        /// <summary>
        /// Gets or sets the average rating of the product.
        /// </summary>
        decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the total number of ratings for the product.
        /// </summary>
        int Count { get; set; }
    }
}