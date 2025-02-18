using Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct;

namespace Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct
{
    /// <summary>
    /// Represents the response returned after get a list of sale product.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an product,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class ListSaleProductResult
    {
        public List<GetSaleProductResult> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
    }
}
