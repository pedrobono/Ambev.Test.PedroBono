using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Repository;
using Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct;
using Ambev.Test.PedroBono.Application.Sales.GetSale;
using Ambev.Test.PedroBono.Application.Products.GetProduct;

namespace Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct
{

    /// <summary>
    /// Handler for processing CreateSaleProductCommand requests
    /// </summary>
    public class CreateSaleProductHandler : IRequestHandler<CreateSaleProductCommand, CreateSaleProductResult>
    {
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of CreateSaleProductHandler
        /// </summary>
        /// <param name="saleProductRepository">The saleProduct repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for CreateSaleProductCommand</param>
        public CreateSaleProductHandler(ISaleProductRepository saleProductRepository, IMapper mapper, IMediator mediator)
        {
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the CreateSaleProductCommand request
        /// </summary>
        /// <param name="command">The CreateSaleProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created saleProduct details</returns>
        public async Task<CreateSaleProductResult> Handle(CreateSaleProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var responseSale = await _mediator.Send(new GetSaleCommand() { SaleId = command.SaleId }, cancellationToken);
            var sale = _mapper.Map<GetSaleResult>(responseSale) ?? throw new KeyNotFoundException("Sale not found");

            if (sale.Products.Any(product => product.Product.Id == command.ProductId))
                throw new InvalidOperationException("Product already exists in the sale.");

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

            var createdSaleProduct = await _saleProductRepository.CreateAsync(saleProduct, cancellationToken);

            var result = _mapper.Map<CreateSaleProductResult>(await _saleProductRepository.GetByIdAsync(createdSaleProduct.Id));

            return result;
        }
    }
}
