using MediatR;

namespace Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct
{
    public class UpdateSaleProductCommand : IRequest<UpdateSaleProductResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the saleProduct.
        /// </summary>
        public int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product to be updated in the sale.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the sale.
        /// </summary>
        public int Qty { get; set; }
    }
}
