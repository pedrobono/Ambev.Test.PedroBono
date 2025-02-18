using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents a product associated with a sale.
    /// </summary>
    /// <remarks>
    /// This class contains information about a product in a sale, including the 
    /// sale it belongs to, the product details, the quantity, unit price, total 
    /// price, discount, and status. The discount is set to 0 by default but 
    /// is never null, while the status is never null either.
    /// </remarks>
    public class SaleProduct : BaseEntity, ISaleProduct
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale that this product belongs to.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the sale that this product is part of.
        /// </summary>
        public Sale Sale { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product associated with the sale.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product details for this sale product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the product. This value is never null and is set to 0 by default.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product purchased in the sale.
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total price for the product, calculated as 
        /// (UnitPrice * Qty - Discount).
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale product.
        /// The status is never null.
        /// </summary>
        public SaleProductStatus Status { get; set; }

        /// <summary>
        /// Validates the SaleProduct object using the SaleProductValidator.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed.
        /// - Errors: Collection of validation errors if any rules failed.
        /// </returns>
        /// <remarks>
        /// The validation checks ensure that all fields (SaleId, ProductId, Qty, 
        /// UnitPrice, Total, Discount, and Status) are correctly populated and 
        /// follow the required rules.
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            // Instantiate the validator for SaleProduct
            var validator = new SaleProductValidator();

            // Perform validation
            var result = validator.Validate(this);

            // Return the result in a ValidationResultDetail format
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o).ToList()
            };
        }

    }
}
