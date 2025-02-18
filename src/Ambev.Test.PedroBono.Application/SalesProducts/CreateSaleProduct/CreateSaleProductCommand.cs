using MediatR;

namespace Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct
{
    public class CreateSaleProductCommand : IRequest<CreateSaleProductResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Qty { get; set; }
    }
}