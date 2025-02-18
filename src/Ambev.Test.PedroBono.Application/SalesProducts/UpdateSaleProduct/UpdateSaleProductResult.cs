using Ambev.Test.PedroBono.Application.Products.GetProduct;

namespace Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct
{
    public class UpdateSaleProductResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale product.
        /// </summary>
        public int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public GetProductResult Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total price for this product in the sale.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the sale product.
        /// </summary>
        public int Discount { get; set; }
    }
}
