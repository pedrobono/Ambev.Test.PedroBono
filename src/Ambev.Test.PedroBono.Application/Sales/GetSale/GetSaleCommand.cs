using Ambev.Test.PedroBono.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.GetSale
{
    /// <summary>
    /// Command for geting a sale.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for geting a sale, 
    /// including customer ID, user ID (who is processing the sale), the products 
    /// involved in the sale, and the sale status. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="GetSaleResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="GetSaleCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// 
    /// The <see cref="GetSaleCommand"/> is used as an intermediary between 
    /// the API layer and the domain layer, where the sale will be created and 
    /// processed. This command can be mapped from incoming requests, such as 
    /// the <see cref="GetSaleResult"/> in the Web API, ensuring that only 
    /// valid data is passed to the handler.
    /// </remarks>
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be updated.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale to be updated.
        /// </summary>
        public int SaleProductId { get; set; }
    }
}
