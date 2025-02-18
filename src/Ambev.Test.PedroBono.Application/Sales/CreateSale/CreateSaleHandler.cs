using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Repository;

namespace Ambev.Test.PedroBono.Application.Sales.CreateSale
{

    /// <summary>
    /// Handler for processing CreateSaleCommand requests
    /// </summary>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of CreateSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for CreateSaleCommand</param>
        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the CreateSaleCommand request
        /// </summary>
        /// <param name="command">The CreateSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Sale>(command);

            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

            foreach (var product in command.Products)
            {
                product.SaleId = createdSale.Id;
                await _mediator.Send(product, cancellationToken);
            }

            var result1 = await _saleRepository.GetByIdAsync(createdSale.Id);

            var result = _mapper.Map<CreateSaleResult>(result1);

            return result;
        }
    }
}
