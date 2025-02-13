using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.DeleteCart
{
    /// <summary>
    /// Command for deleting a shopping cart.
    /// </summary>
    /// <remarks>
    /// This command is used to delete a shopping cart based on its unique identifier.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="DeleteCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="DeleteCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly populated and follow the required rules.
    /// </remarks>
    public class DeleteCartCommand : IRequest<DeleteCartResult>
    {
        /// <summary>
        /// Gets the unique identifier of the cart to be deleted.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCartCommand"/> class.
        /// </summary>
        /// <param name="id">The unique ID of the cart to be deleted.</param>
        public DeleteCartCommand(int id)
        {
            Id = id;
        }
    }
}
