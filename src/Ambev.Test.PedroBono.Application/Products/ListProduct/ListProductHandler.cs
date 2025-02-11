using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.Application.Products.ListProduct
{
    /// <summary>
    /// Handler for processing ListProductCommand requests
    /// </summary>
    public class ListProductHandler : IRequestHandler<ListProductCommand, ListProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Handles the ListProductCommand request
        /// </summary>
        /// <param name="request">The ListProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of product details if found</returns>
        public async Task<ListProductResult> Handle(ListProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var map = _mapper.Map<PaginedFilter>(request);

            var products = await _productRepository.ListPaginatedAsync(map, cancellationToken);

            return _mapper.Map<ListProductResult>(products);
        }
    }
}
