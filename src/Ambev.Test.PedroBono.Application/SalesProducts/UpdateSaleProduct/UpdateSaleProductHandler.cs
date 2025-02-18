using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.Application.Products.GetProduct;

namespace Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct
{

    /// <summary>
    /// Handler for processing UpdateSaleProductCommand requests
    /// </summary>
    public class UpdateSaleProductHandler : IRequestHandler<UpdateSaleProductCommand, UpdateSaleProductResult>
    {
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of UpdateSaleProductHandler
        /// </summary>
        /// <param name="saleProductRepository">The saleProduct repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UpdateSaleProductHandler(ISaleProductRepository saleProductRepository, IMapper mapper, IMediator mediator)
        {
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the UpdateSaleProductCommand request
        /// </summary>
        /// <param name="command">The UpdateSaleProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated saleProduct details</returns>
        public async Task<UpdateSaleProductResult> Handle(UpdateSaleProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingSaleProduct = await _saleProductRepository.GetByIdAndSaleIdAsync(command.SaleProductId, command.SaleId, cancellationToken);

            if (existingSaleProduct == null)
                throw new KeyNotFoundException($"SaleProduct with ID {command.SaleProductId} not found for the sale {command.SaleId}");

            var responseproduct = await _mediator.Send(new GetProductCommand(command.ProductId), cancellationToken);
            var product = _mapper.Map<GetProductResult>(responseproduct) ?? throw new KeyNotFoundException("Product not found"); ;

            var saleProduct = _mapper.Map<SaleProduct>(command);
            saleProduct.UnitPrice = product.Price;

            saleProduct.Discount = saleProduct.Qty switch
            {
                >= 10 => 20,  // 20% discount for 10 or more items
                >= 4 => 10,  // 10% discount for 4-9 items
                _ => 0,       // No discount for less than 4 items
            };

            saleProduct.Total = saleProduct.Qty * saleProduct.UnitPrice * (1 - saleProduct.Discount / 100m);


            var updatedSaleProduct = await _saleProductRepository.UpdateAsync(saleProduct, cancellationToken);
            var result = _mapper.Map<UpdateSaleProductResult>(await _saleProductRepository.GetByIdAsync(saleProduct.Id, cancellationToken));
            return result;
        }
    }
}
