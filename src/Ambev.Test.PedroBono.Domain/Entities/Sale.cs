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
    /// Represents a sale transaction in the system, including details about the customer, user, products, and sale status.
    /// </summary>
    /// <remarks>
    /// This class stores the necessary information for a sale, such as the customer details, the user who processed the sale,
    /// the list of products involved in the sale, and the current status of the sale. It also includes a validation method
    /// to ensure the sale data adheres to the required rules.
    /// </remarks>
    public class Sale : BaseEntity, ISale
    {
        /// <summary>
        /// Gets or sets the date when the sale occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer associated with the sale.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer details related to the sale.
        /// </summary>
        public User Customer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who processed the sale.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who processed the sale.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the collection of products involved in the sale.
        /// </summary>
        public ICollection<SaleProduct> Products { get; set; }

        /// <summary>
        /// Gets or sets the current status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Performs validation of the user entity using the UserValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Username format and length</list>
        /// <list type="bullet">Email format</list>
        /// <list type="bullet">Phone number format</list>
        /// <list type="bullet">Password complexity requirements</list>
        /// <list type="bullet">Role validity</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public Sale()
        {
            Date = DateTime.UtcNow;
        }
    }
}
