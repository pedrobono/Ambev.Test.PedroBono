using Ambev.Test.PedroBono.Application.Products.CreateProduct;
using Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct;
using Ambev.Test.PedroBono.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.CreateSale
{
    /// <summary>
    /// Command for creating a new sale.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a sale, 
    /// including customer ID, user ID (who is processing the sale), the products 
    /// involved in the sale, and the sale status. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
    /// <see cref="CreateSaleResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateSaleCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure the fields are correctly 
    /// populated and follow the required rules.
    /// 
    /// The <see cref="CreateSaleCommand"/> is used as an intermediary between 
    /// the API layer and the domain layer, where the sale will be created and 
    /// processed. This command can be mapped from incoming requests, such as 
    /// the <see cref="CreateSaleResult"/> in the Web API, ensuring that only 
    /// valid data is passed to the handler.
    /// </remarks>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Gets or sets the customer ID associated with the sale.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the user ID who is processing the sale.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the list of products in the sale.
        /// </summary>
        public List<CreateSaleProductCommand> Products { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
