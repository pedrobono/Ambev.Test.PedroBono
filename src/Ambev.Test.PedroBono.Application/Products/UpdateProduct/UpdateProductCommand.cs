using Ambev.Test.PedroBono.Common.Validation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Products.UpdateProduct
{
    /// <summary>
    /// Command for creating a new product.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a product, 
    /// including productname, password, phone number, email, status, and role. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly Updated product.
        /// </summary>
        /// <value>A Id that uniquely identifies the Updated product in the system.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name or title of the product.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the price of the product, represented as a decimal.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the product.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the category or type the product belongs to.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the image of the product as a byte array.
        /// This property is optional, and can be null if no description is provided.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the average rating of the product, which is calculated from user reviews.
        /// </summary>
        public decimal Rate { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total number of ratings the product has received.
        /// </summary>
        public int Count { get; set; } = 0;


        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
