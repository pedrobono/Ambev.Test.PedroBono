using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Repository;
using Ambev.Test.PedroBono.Application.Carts.CreateCartProduct;

namespace Ambev.Test.PedroBono.Application.Carts.CreateCart
{
    /// <summary>
    /// Handler for processing CreateCartCommand requests
    /// </summary>
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="cartProductRepository">The AutoMapper instance</param>
        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, ICartProductRepository cartProductRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _cartProductRepository = cartProductRepository;
        }

        /// <summary>
        /// Handles the CreateCartCommand request
        /// </summary>
        /// <param name="command">The CreateCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart details</returns>
        public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCartCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = _mapper.Map<Cart>(command);

            var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);

            await _cartProductRepository.DeleteAllByCartIdAsync(cart.Id, cancellationToken);

            foreach (var item in command.Products)
            {
                var cartProduct = _mapper.Map<CartProduct>(item);
                cartProduct.CartId = createdCart.Id;
                await _cartProductRepository.CreateAsync(cartProduct, cancellationToken);
            }

            return _mapper.Map<CreateCartResult>(await _cartRepository.GetByIdAsync(createdCart.Id));
        }
    }
}
