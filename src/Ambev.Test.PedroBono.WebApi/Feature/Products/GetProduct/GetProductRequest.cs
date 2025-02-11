namespace Ambev.Test.PedroBono.WebApi.Feature.Products.GetProduct
{
    /// <summary>
    /// Request model for retrive a product by ID
    /// </summary>
    public class GetProductRequest
    {
            /// <summary>
            /// The unique identifier of the product to retrive
            /// </summary>
            public int Id { get; set; }
        }
}
