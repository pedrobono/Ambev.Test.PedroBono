using MediatR;

namespace Ambev.Test.PedroBono.Application.Sales.ListSale
{
    /// <summary>
    /// Request model for getting a list of product's
    /// </summary>
    public class ListSaleCommand : IRequest<ListSaleResult>
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
        /// Ordering of results (e.g., "productname asc, email desc")
        /// </summary>
        public string Order { get; set; }
    }
}
