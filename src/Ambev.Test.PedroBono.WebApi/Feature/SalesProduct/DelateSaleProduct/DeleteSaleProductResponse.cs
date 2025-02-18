namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.DelateSaleProduct
{
    public class DeleteSaleProductResponse
    {
        /// <summary>
        /// Gets or sets the message indicating the result of the deletion attempt.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the ID of the deleted sale product.
        /// </summary>
        public int SaleProductId { get; set; }
    }
}
