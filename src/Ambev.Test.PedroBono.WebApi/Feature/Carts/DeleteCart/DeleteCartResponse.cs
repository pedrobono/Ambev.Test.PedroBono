namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.DeleteCart
{
    /// <summary>
    /// Represents the response returned after deleting a shopping cart.
    /// </summary>
    public class DeleteCartResponse
    {
        /// <summary>
        /// Gets or sets the result if the delection was successfully
        /// </summary>
        public bool Result { get; set; } = false;

        /// <summary>
        ///  Gets or sets the message of the delection
        /// </summary>
        public string Message { get; set; }
    }
}
