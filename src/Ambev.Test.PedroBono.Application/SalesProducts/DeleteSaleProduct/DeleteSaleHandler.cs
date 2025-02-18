using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.SalesProducts.DeleteSaleProduct
{
    /// <summary>
    /// Handler for processing DeleteSaleProductCommand requests
    /// </summary>
    public class DeleteSaleProductHandler : IRequestHandler<DeleteSaleProductCommand, DeleteSaleProductResult>
    {
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of DeleteSaleProductHandler
        /// </summary>
        /// <param name="saleProductRepository">The saleProduct repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public DeleteSaleProductHandler(ISaleProductRepository saleProductRepository, IMapper mapper)
        {
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the DeleteSaleProductCommand request
        /// </summary>
        /// <param name="request">The DeleteSaleProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The saleProduct details if found</returns>
        public async Task<DeleteSaleProductResult> Handle(DeleteSaleProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleProduct = await _saleProductRepository.GetByIdAndSaleIdAsync(request.SaleProductId, request.SaleId, cancellationToken);
            if (saleProduct == null)
                throw new KeyNotFoundException($"SaleProduct with ID {request.SaleProductId} not found for the sale {request.SaleId}");

            var ok = await _saleProductRepository.DeleteAsync(request.SaleProductId, cancellationToken);

            if (!ok)
                throw new KeyNotFoundException($"SaleProduct with ID {request.SaleProductId} not found");

            return new DeleteSaleProductResult() { Message = "SaleProduct deleted sucefully!", SaleProductId = request.SaleProductId };
        }
    }
}
