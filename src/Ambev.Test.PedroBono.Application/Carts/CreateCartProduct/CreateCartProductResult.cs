namespace Ambev.Test.PedroBono.Application.Carts.CreateCartProduct
{
    /// <summary>
    /// Represents the result of adding a product to the shopping cart.
    /// </summary>
    public class CreateCartProductResult
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
