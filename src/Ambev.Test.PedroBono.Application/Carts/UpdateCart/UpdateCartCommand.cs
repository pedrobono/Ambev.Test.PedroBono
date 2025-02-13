using Ambev.Test.PedroBono.Application.Carts.CreateCartProduct;
using Ambev.Test.PedroBono.Common.Validation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.UpdateCart
{
    /// <summary>
    /// Command for creating a new cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a cart, 
    /// including cartname, password, phone number, email, status, and role. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateCartCommand : IRequest<UpdateCartResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly Updated cart.
        /// </summary>
        /// <value>A Id that uniquely identifies the Updated cart in the system.</value>
        public int Id { get; set; }
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


        public ValidationResultDetail Validate()
        {
            var validator = new UpdateCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
