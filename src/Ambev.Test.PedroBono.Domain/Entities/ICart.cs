using Ambev.Test.PedroBono.Common.Validation;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Interface representing a shopping cart in an e-commerce system.
    /// </summary>
    /// <remarks>
    /// This interface defines the essential properties and methods 
    /// that a cart should have, such as UserId, CartProducts, Date, CreatedAt, and UpdatedAt.
    /// </remarks>
    public interface ICart
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cart.
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets the collection of products added to the cart.
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
    }

}