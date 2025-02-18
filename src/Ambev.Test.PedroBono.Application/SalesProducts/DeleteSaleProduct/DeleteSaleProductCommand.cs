using MediatR;

namespace Ambev.Test.PedroBono.Application.SalesProducts.DeleteSaleProduct
{
    public class DeleteSaleProductCommand : IRequest<DeleteSaleProductResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be deleted.
        /// </summary>
        public int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; set; }
    }
}
