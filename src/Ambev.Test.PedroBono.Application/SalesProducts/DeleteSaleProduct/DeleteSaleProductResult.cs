namespace Ambev.Test.PedroBono.Application.SalesProducts.DeleteSaleProduct
{
    public class DeleteSaleProductResult
    {
        /// <summary>
        /// Gets or sets a message indicating whether the sale was successfully deleted.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the ID of the deleted sale.
        /// </summary>
        public int SaleProductId { get; set; }
    }
}
