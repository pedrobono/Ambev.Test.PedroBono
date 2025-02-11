﻿using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;

namespace Ambev.Test.PedroBono.Application.Products.UpdateProduct
{

    /// <summary>
    /// Handler for processing UpdateProductCommand requests
    /// </summary>
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateProductHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for UpdateProductCommand</param>
        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateProductCommand request
        /// </summary>
        /// <param name="command">The UpdateProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated product details</returns>
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = await _productRepository.GetByIdAsync(command.Id, cancellationToken);

            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {command.Id} not found");

            var product = _mapper.Map<Product>(command);
            var updatedProduct = await _productRepository.UpdateAsync(product, cancellationToken);
            var result = _mapper.Map<UpdateProductResult>(updatedProduct);
            return result;
        }
    }
}
