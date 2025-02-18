using Ambev.Test.PedroBono.Application.Sales.GetSale;

namespace Ambev.Test.PedroBono.Application.Sales.ListSale
{
    /// <summary>
    /// Represents the response returned after get a list of sale by.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an product,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class ListSaleResult
    {
        public List<GetSaleResult> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
    }
}
