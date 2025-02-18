using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.UpdateSale
{
    public class UpdateSaleRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be updated.
        /// </summary>
        internal int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer associated with the sale.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who processed the sale.
        /// </summary>
        internal int UserId { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
