namespace Ambev.Test.PedroBono.WebApi.Feature.Products.ListProduct
{
    /// <summary>
    /// Request model for getting a list of user's
    /// </summary>
    public class ListProductRequest
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
