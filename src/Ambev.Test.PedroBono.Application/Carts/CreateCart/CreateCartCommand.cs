using Ambev.Test.PedroBono.Application.Carts.CreateCartProduct;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.CreateCart
{
    /// <summary>
    /// Command for creating a new shopping cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a cart, 
    /// including the user ID, cart creation date, and a list of products to be added to the cart. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="CreateCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly populated and follow the required rules.
    /// </remarks>
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
        /// Gets or sets the ID of the user associated with the cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart is created or the desired date for the cart.
        /// The date should be in the format "DD/MM/YYYY".
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products to be added to the cart.
        /// </summary>
        public List<CreateCartProductCommand> Products { get; set; }
    }
}
