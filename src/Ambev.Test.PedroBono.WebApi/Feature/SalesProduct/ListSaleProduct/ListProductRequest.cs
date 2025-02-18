namespace Ambev.Test.PedroBono.WebApi.Feature.SaleProducts.ListSaleProduct
{
    /// <summary>
    /// Request model for getting a list of SaleProduct's
    /// </summary>
    public class ListSaleProductRequest
    {
        /// <summary>
        /// Page number for pagination (default: 1)
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Number of items per page(default: 10)
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Ordering of results (e.g., "username asc, email desc")
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; internal set; }
    }
}
