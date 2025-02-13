using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.Domain.Validation;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents a product in the system.
    /// </summary>
    /// <remarks>
    /// This class defines the properties of a product, including the title, price, description, category, image, rate, and the total number of ratings.
    /// It implements the <see cref="IProduct"/> interface and inherits from <see cref="BaseEntity"/> which provides common properties such as an ID.
    /// </remarks>
    public class Product : BaseEntity, IProduct
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

        /// <summary>
        /// Gets or sets the Carts associated with this Product.
        /// </summary>
        public ICollection<CartProduct> CartProducts { get; set; }

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// Sets the <see cref="CreatedAt"/> property to the current UTC time upon object creation.
        /// </summary>
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Validates the current instance of the <see cref="Product"/> class using the <see cref="ProductValidator"/>.
        /// Returns a <see cref="ValidationResultDetail"/> object that indicates whether the validation passed, 
        /// along with a list of validation errors if any occurred.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> object containing the validation result and error details.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
