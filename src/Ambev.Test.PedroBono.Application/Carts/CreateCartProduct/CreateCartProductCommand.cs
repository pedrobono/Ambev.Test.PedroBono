using FluentValidation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.CreateCartProduct
{
    /// <summary>
    /// Command for adding a product to the shopping cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for adding a product to the cart, 
    /// including the product's unique identifier and the quantity to be added. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="CreateCartProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateCartProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateCartProductCommand : IRequest<CreateCartProductResult>
    {

        /// <summary>
        /// Gets or sets the unique identifier of the product to be added to the cart.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product to be added to the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}
