﻿using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.GetCart
{
    /// <summary>
    /// Handler for processing GetCartCommand requests
    /// </summary>
    public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetCartCommand request
        /// </summary>
        /// <param name="request">The GetCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details if found</returns>
        public async Task<GetCartResult> Handle(GetCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cart == null)
                throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

            return _mapper.Map<GetCartResult>(cart);
        }
    }
}
