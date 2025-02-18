using Ambev.Test.PedroBono.WebApi.Feature.Users;
using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer making the sale.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who processed the sale.
        /// </summary>
        internal int UserId { get; set; }

        /// <summary>
        /// Gets or sets the collection of products involved in the sale.
        /// </summary>
        public List<CreateSaleProductRequest> Products { get; set; } = new List<CreateSaleProductRequest>();
    }
}