namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.DeleteSale
{
    public class DeleteSaleResponse
    {
        /// <summary>
        /// Gets or sets a message indicating whether the sale was successfully deleted.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the ID of the deleted sale.
        /// </summary>
        public int SaleId { get; set; }
    }
}
