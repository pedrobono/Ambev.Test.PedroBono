using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.ListCart
{
    /// <summary>
    /// Request model for getting a list of cart's
    /// </summary>
    public class ListCartCommand : IRequest<ListCartResult>
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
        /// Ordering of results (e.g., "date asc, userid desc")
        /// </summary>
        public string Order { get; set; }
    }
}
