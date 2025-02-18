using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Enums;

namespace Ambev.Test.PedroBono.Domain.Entities
{
    /// <summary>
    /// Interface representing a product in a sale.
    /// </summary>
    /// <remarks>
    /// This interface defines the essential properties and methods 
    /// that a product in a sale should have, such as SaleId, ProductId, 
    /// Quantity, UnitPrice, Discount, Total, and Status.
    /// </remarks>
    public interface ISaleProduct
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale that this product belongs to.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the product associated with the sale.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product in the sale.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the product. This value is never null.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Gets or sets the total price of the product in the sale.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale product.
        /// </summary>
        public SaleProductStatus Status { get; set; }
    }

}