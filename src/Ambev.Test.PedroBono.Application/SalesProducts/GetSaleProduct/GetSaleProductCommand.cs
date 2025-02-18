using Ambev.Test.PedroBono.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct
{
    /// <summary>
    /// Command for geting a sale product.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for geting a sale product, 
    ///  the products involved in the sale. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="GetSaleProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="GetSaleProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// 
    /// The <see cref="GetSaleProductCommand"/> is used as an intermediary between 
    /// the API layer and the domain layer, where the sale will be created and 
    /// processed. This command can be mapped from incoming requests, such as 
    /// the <see cref="GetSaleProductResult"/> in the Web API, ensuring that only 
    /// valid data is passed to the handler.
    /// </remarks>
    public class GetSaleProductCommand : IRequest<GetSaleProductResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the saleProduct to be updated.
        /// </summary>
        public int SaleProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public int SaleId { get; set; }
    }
}
