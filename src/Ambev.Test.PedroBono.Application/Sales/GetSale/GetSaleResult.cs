using Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.GetSale
{
    public class GetSaleResult
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
        public List<GetSaleProductResult> Products { get; set; } = new List<GetSaleProductResult>();

        /// <summary>
        /// Gets or sets the status of the sale (e.g., Pending, Completed).
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
