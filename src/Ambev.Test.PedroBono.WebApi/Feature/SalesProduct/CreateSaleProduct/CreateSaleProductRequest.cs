namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct
{
    public class CreateSaleProductRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        internal int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Qty { get; set; }
    }
}