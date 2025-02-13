using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Carts.DeleteCart
{
    /// <summary>
    /// Handler for processing DeleteCartCommand requests
    /// </summary>
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of DeleteCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public DeleteCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the DeleteCartCommand request
        /// </summary>
        /// <param name="request">The DeleteCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details if found</returns>
        public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cart == null)
                return new DeleteCartResult() { Result = false, Message = $"Cart with ID {request.Id} not found" };

            var ok = await _cartRepository.DeleteAsync(request.Id, cancellationToken);

            return new DeleteCartResult() { Result = ok, Message = ok ? "Cart delected suceffuly" : "Card cannot be deleted" };
        }
    }
}
