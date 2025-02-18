namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.DelateSaleProduct
{
    public class DeleteSaleProductRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale product to be deleted.
        /// </summary>
        public int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; set; }
    }
}
