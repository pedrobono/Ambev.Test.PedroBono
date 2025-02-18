using Ambev.Test.PedroBono.Common.Validation;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Interface representing a product in a shopping cart.
    /// </summary>
    /// <remarks>
    /// This interface defines the essential properties and methods 
    /// that a product in the shopping cart should have, such as CartId, ProductId, 
    /// Quantity, and associated Cart and Product entities.
    /// </remarks>
    public interface ICartProduct
    {
        /// <summary>
        /// Gets or stes the id of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product associated with this cart item.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// This is used to relate the CartProduct to a specific Product entity.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the cart that this product belongs to.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the cart.
        /// This links the CartProduct to a specific Cart entity.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the cart.
        /// This represents how many units of the product the user has added to the cart.
        /// </summary>
        public int Qty { get; set; }
    }

}