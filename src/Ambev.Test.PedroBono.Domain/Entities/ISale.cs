using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Enums;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Represents a sale transaction in an e-commerce system.
    /// This interface defines the essential properties and methods 
    /// that a sale should have, including customer, user, products, and status.
    /// </summary>
    public interface ISale
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sale.
        /// </summary>
        public int Id { get; set; }

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
    }

}