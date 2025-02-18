using Ambev.Test.PedroBono.Domain.Enums;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct
{
    public class UpdateSaleProductRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the saleProduct.
        /// </summary>
        internal int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product to be updated in the sale.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; internal set; }
    }
}
