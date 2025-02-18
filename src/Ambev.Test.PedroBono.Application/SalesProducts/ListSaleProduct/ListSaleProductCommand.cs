using MediatR;

namespace Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct
{
    /// <summary>
    /// Request model for getting a list of product's
    /// </summary>
    public class ListSaleProductCommand : IRequest<ListSaleProductResult>
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

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; internal set; }
    }
}
