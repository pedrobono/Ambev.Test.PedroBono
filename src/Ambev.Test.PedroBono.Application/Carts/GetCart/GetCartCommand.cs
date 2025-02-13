using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.GetCart
{
    /// <summary>
    /// Command for retrieving a shopping cart.
    /// </summary>
    /// <remarks>
    /// This command is used to retrieve a shopping cart based on its unique identifier.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="GetCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="GetCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly populated and follow the required rules.
    /// </remarks>
    public class GetCartCommand : IRequest<GetCartResult>
    {
        /// <summary>
        /// Gets the unique identifier of the cart to retrieve.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartCommand"/> class.
        /// </summary>
        /// <param name="id">The unique ID of the cart to retrieve.</param>
        public GetCartCommand(int id)
        {
            Id = id;
        }
    }
}
