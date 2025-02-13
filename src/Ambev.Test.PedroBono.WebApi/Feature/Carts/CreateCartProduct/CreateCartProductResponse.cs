namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct
{
    /// <summary>
    /// Represents the response for a product added to the shopping cart.
    /// </summary>
    public class CreateCartProductResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product in the cart.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product added to the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}
