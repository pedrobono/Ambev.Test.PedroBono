using Ambev.Test.PedroBono.Application.Carts.GetCart;

namespace Ambev.Test.PedroBono.Application.Carts.ListCart
{
    /// <summary>
    /// Represents the response returned after get a cart.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an product,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class ListCartResult
    {
        public List<GetCartResult> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
    }
}
