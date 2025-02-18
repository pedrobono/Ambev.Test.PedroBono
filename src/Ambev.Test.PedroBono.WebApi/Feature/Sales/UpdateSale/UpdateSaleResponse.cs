using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the updated sale.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale occurred.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale after update.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of products involved in the sale.
        /// </summary>
        public List<GetSaleProductResponse> Products { get; set; } = new List<GetSaleProductResponse>();

        /// <summary>
        /// Gets or sets the customer name associated with the updated sale.
        /// </summary>
        public string CustomerName { get; set; }
    }
}
