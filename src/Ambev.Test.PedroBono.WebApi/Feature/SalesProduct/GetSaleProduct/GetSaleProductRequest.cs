namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct
{
    public class GetSaleProductRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale product.
        /// </summary>
        public int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; internal set; }
    }
}
