namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.ListSale
{
    /// <summary>
    /// Request model for getting a list of Sale's
    /// </summary>
    public class ListSaleRequest
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
    }
}
