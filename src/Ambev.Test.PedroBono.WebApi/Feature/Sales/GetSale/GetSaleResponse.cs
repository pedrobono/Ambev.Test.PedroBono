using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.GetSale
{
    public class GetSaleResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the sale.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the date of the sale.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the collection of products involved in the sale.
        /// </summary>
        public List<GetSaleProductResponse> Products { get; set; }
    }    
}
