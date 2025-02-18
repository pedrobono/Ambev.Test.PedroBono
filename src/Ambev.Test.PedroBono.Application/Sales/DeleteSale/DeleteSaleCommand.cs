using Ambev.Test.PedroBono.Application.Products.CreateProduct;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Sales.DeleteSale
{
    public class DeleteSaleCommand : IRequest<DeleteSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be deleted.
        /// </summary>
        public int SaleId { get; set; }
    }
}
