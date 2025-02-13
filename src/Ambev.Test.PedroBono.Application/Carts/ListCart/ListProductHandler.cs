using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.Application.Carts.ListCart
{
    /// <summary>
    /// Handler for processing ListCartCommand requests
    /// </summary>
    public class ListCartHandler : IRequestHandler<ListCartCommand, ListCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public ListCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Handles the ListCartCommand request
        /// </summary>
        /// <param name="request">The ListCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of cart details if found</returns>
        public async Task<ListCartResult> Handle(ListCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var map = _mapper.Map<PaginedFilter>(request);

            var carts = await _cartRepository.ListPaginatedAsync(map, cancellationToken);

            return _mapper.Map<ListCartResult>(carts);
        }
    }
}
