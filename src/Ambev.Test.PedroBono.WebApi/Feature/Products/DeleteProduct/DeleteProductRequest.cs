namespace Ambev.Test.PedroBono.WebApi.Feature.Products.DeleteProduct
{
    /// <summary>
    /// Request model for Deleteting a product by ID
    /// </summary>
    public class DeleteProductRequest
    {
            /// <summary>
            /// The unique identifier of the product to delete
            /// </summary>
            public int Id { get; set; }
        }
}
