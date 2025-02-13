namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct
{
    /// <summary>
    /// Represents a product to be added to the shopping cart during the creation process.
    /// </summary>
    public class CreateCartProductRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product to be added to the cart.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product to be added to the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}
