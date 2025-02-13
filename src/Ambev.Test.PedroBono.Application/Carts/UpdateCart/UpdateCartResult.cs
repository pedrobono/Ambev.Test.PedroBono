using Ambev.Test.PedroBono.Application.Carts.CreateCartProduct;

namespace Ambev.Test.PedroBono.Application.Carts.UpdateCart
{
    /// <summary>
    /// Represents the response returned after retrive a cart by an ID.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an cart,
    /// which can be used for subsequent operations or reference.
    /// </remarks>a
    public class UpdateCartResult
    {

        /// <summary>
        /// Gets or sets the unique identifier of an cart.
        /// </summary>
        /// <value>A Id that uniquely identifies the created cart in the system.</value>
        public int Id { get; set; }

        /// Gets or sets the ID of the user associated with the cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart is created or the desired date for the cart.
        /// The date should be in the format "DD/MM/YYYY".
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products on the cart.
        /// </summary>
        public List<CreateCartProductResult> Products { get; set; }
    }
}
