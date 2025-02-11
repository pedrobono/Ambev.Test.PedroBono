using Ambev.Test.PedroBono.Application.Products.GetProduct;

namespace Ambev.Test.PedroBono.Application.Products.ListProduct
{
    /// <summary>
    /// Represents the response returned after get a product by an ID.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an product,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class ListProductResult
    {
        public List<GetProductResult> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
    }
}
