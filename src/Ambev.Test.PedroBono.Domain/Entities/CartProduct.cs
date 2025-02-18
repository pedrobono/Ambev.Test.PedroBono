using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents a product added to a shopping cart in an e-commerce system.
    /// This class contains information about the product, the cart, and the quantity of the product in the cart.
    /// </summary>
    public class CartProduct : BaseEntity, ICartProduct
    {
        /// <summary>
        /// Gets or sets the product associated with this cart item.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// This is used to relate the CardProduct to a specific Product entity.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the cart that this product belongs to.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the cart.
        /// This links the CardProduct to a specific Cart entity.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the cart.
        /// This represents how many units of the product the user has added to the cart.
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Validates the current instance of the <see cref="CartProduct"/> class using the <see cref="CartProductValidator"/>.
        /// Returns a <see cref="ValidationResultDetail"/> object that indicates whether the validation passed, 
        /// along with a list of validation errors if any occurred.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> object containing the validation result and error details.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CartProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
