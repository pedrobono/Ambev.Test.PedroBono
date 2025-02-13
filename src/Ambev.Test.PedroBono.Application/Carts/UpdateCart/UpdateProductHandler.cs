using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.Application.Carts.CreateCart;

namespace Ambev.Test.PedroBono.Application.Carts.UpdateCart
{

    /// <summary>
    /// Handler for processing UpdateCartCommand requests
    /// </summary>
    public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for UpdateCartCommand</param>
        public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper, ICartProductRepository cartProductRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _cartProductRepository = cartProductRepository;
        }

        /// <summary>
        /// Handles the UpdateCartCommand request
        /// </summary>
        /// <param name="command">The UpdateCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated cart details</returns>
        public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);

            if (existingCart == null)
                throw new KeyNotFoundException($"Cart with ID {command.Id} not found");


            var cart = _mapper.Map<Cart>(command);
            var updatedCart = await _cartRepository.UpdateAsync(cart, cancellationToken);

            await _cartProductRepository.DeleteAllByCartIdAsync(updatedCart.Id, cancellationToken);

            foreach (var item in command.Products)
            {
                var cartProduct = _mapper.Map<CartProduct>(item);
                cartProduct.CartId = updatedCart.Id;
                await _cartProductRepository.CreateAsync(cartProduct, cancellationToken);
            }

            var result = _mapper.Map<UpdateCartResult>(await _cartRepository.GetByIdAsync(updatedCart.Id));
            return result;
        }
    }
}
