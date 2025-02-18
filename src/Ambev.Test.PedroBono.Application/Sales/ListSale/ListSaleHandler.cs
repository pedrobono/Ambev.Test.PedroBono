using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.Application.Sales.ListSale
{
    /// <summary>
    /// Handler for processing ListSaleCommand requests
    /// </summary>
    public class ListSaleHandler : IRequestHandler<ListSaleCommand, ListSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public ListSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Handles the ListSaleCommand request
        /// </summary>
        /// <param name="request">The ListSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of sale details if found</returns>
        public async Task<ListSaleResult> Handle(ListSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var map = _mapper.Map<PaginedFilter>(request);

            var sales = await _saleRepository.ListPaginatedAsync(map, cancellationToken);

            return _mapper.Map<ListSaleResult>(sales);
        }
    }
}
