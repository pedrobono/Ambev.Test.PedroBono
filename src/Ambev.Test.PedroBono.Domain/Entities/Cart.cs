using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.Domain.Validation;
using System.Collections.Generic;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents a shopping cart for a user in an e-commerce system.
    /// The class contains information about the user, the date the cart was created, 
    /// and metadata about the cart's creation and updates.
    /// </summary>
    public class Cart: BaseEntity, ICart
    {
        /// <summary>
        /// Gets or sets the user associated with this cart.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the cart.
        /// This is a foreign key for the User entity.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the cart was created.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this cart.
        /// </summary>
        public ICollection<CartProduct> CartProducts { get; set; }

        /// <summary>
        /// Gets the date and time when the cart was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the cart was last updated.
        /// This property is nullable since the cart might not have been updated yet.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// The <see cref="CreatedAt"/> property is set to the current UTC time.
        /// </summary>
        public Cart()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Validates the current instance of the <see cref="Cart"/> class using the <see cref="CartValidator"/>.
        /// Returns a <see cref="ValidationResultDetail"/> object that indicates whether the validation passed, 
        /// along with a list of validation errors if any occurred.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> object containing the validation result and error details.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CartValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
