using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct
{
    /// <summary>
    /// Handler for processing ListSaleProductCommand requests
    /// </summary>
    public class ListSaleProductHandler : IRequestHandler<ListSaleProductCommand, ListSaleProductResult>
    {
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IMapper _mapper;

        public ListSaleProductHandler(ISaleProductRepository saleProductRepository, IMapper mapper)
        {
            _saleProductRepository = saleProductRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Handles the ListSaleProductCommand request
        /// </summary>
        /// <param name="request">The ListSaleProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of saleProduct details if found</returns>
        public async Task<ListSaleProductResult> Handle(ListSaleProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListSaleProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var map = _mapper.Map<PaginedFilter>(request);

            var saleProducts = await _saleProductRepository.ListPaginatedFromSaleAsync(request.SaleId, map, cancellationToken);

            return _mapper.Map<ListSaleProductResult>(saleProducts);
        }
    }
}
