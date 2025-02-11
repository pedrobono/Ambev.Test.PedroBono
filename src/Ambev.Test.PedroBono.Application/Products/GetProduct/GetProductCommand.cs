using MediatR;

namespace Ambev.Test.PedroBono.Application.Products.GetProduct
{
    /// <summary>
    /// Command for creating a retrive product.
    /// </summary>
    /// <remarks>
    /// This command is used to retrive a product, 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="GetProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="GetProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class GetProductCommand : IRequest<GetProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of GetProductCommand
        /// </summary>
        /// <param name="id">The ID of the product to retrieve</param>
        public GetProductCommand(int id)
        {
            Id = id;
        }
    }
}
