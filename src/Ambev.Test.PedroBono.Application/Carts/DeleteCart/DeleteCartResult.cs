namespace Ambev.Test.PedroBono.Application.Carts.DeleteCart
{
    public class DeleteCartResult
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
