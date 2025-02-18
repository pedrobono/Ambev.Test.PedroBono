using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;

namespace Ambev.Test.PedroBono.Application.Sales.UpdateSale
{

    /// <summary>
    /// Handler for processing UpdateSaleCommand requests
    /// </summary>
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for UpdateSaleCommand</param>
        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateSaleCommand request
        /// </summary>
        /// <param name="command">The UpdateSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated sale details</returns>
        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingSale = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);

            if (existingSale == null)
                throw new KeyNotFoundException($"Sale with ID {command.SaleId} not found");

            var sale = _mapper.Map<Sale>(command);
            var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
            var result = _mapper.Map<UpdateSaleResult>(await _saleRepository.GetByIdAsync(sale.Id, cancellationToken));
            return result;
        }
    }
}
