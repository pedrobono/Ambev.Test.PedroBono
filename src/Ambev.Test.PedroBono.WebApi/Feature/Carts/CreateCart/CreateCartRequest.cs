using Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCart
{
    /// <summary>
    /// Represents a request to create a new shopping cart.
    /// </summary>
    public class CreateCartRequest
    {
        /// <summary>
        /// Gets or sets the ID of the user associated with the cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart is created or the desired date for the cart.
        /// The date should be in the format "DD/MM/YYYY".
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products to be added to the cart.
        /// </summary>
        public List<CreateCartProductRequest> Products { get; set; }
    }
}
