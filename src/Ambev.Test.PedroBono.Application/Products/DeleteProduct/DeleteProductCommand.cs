using MediatR;

namespace Ambev.Test.PedroBono.Application.Products.DeleteProduct
{
    /// <summary>
    /// Command for creating a delete product.
    /// </summary>
    /// <remarks>
    /// This command is used to delete a product, 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="DeleteProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="DeleteProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class DeleteProductCommand : IRequest<DeleteProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of DeleteProductCommand
        /// </summary>
        /// <param name="id">The ID of the product to retrieve</param>
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
