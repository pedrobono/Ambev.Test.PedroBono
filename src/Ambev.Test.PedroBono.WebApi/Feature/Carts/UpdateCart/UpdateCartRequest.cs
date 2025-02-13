using Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.UpdateCart
{
    /// <summary>
    /// Represents a request to update a shopping cart.
    /// </summary>
    public class UpdateCartRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Cart.
        /// </summary>
        /// <value>A Id that uniquely identifies the cart in the system.</value>
        internal int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user associated with the cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart is updated or the desired date for the cart.
        /// The date should be in the format "DD/MM/YYYY".
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products to be updated to the cart.
        /// </summary>
        public List<CreateCartProductRequest> Products { get; set; }
    }
}
