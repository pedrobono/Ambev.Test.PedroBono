using Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Domain.Enums;

namespace Ambev.Test.PedroBono.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale that was created.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the updated sale.
        /// </summary>
        public GetUserResult Customer { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the collection of products involved in the sale.
        /// </summary>
        public List<CreateSaleProductResult> Products { get; set; } = new List<CreateSaleProductResult>();

        /// <summary>
        /// Gets or sets the status of the sale (e.g., Pending, Completed).
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
