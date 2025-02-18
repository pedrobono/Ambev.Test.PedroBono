using Ambev.Test.PedroBono.WebApi.Feature.Users;
using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale that was created.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the customer name associated with the updated sale.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale occurred.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the collection of products involved in the sale.
        /// </summary>
        public List<CreateSaleProductResponse> Products { get; set; } = new List<CreateSaleProductResponse>();

        /// <summary>
        /// Gets or sets the status of the sale (e.g., Pending, Completed).
        /// </summary>
        public string Status { get; set; }
    }
}
