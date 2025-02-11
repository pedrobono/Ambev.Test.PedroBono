using Ambev.Test.PedroBono.Application.Products.CreateProduct;
using Ambev.Test.PedroBono.Application.Products.DeleteProduct;
using Ambev.Test.PedroBono.Application.Products.GetProduct;
using Ambev.Test.PedroBono.Application.Products.ListProduct;
using Ambev.Test.PedroBono.Application.Products.UpdateProduct;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Products.CreateProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Products.DeleteProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Products.GetProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Products.ListProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products
{
    /// <summary>
    /// Controller for authentication operations
    /// </summary>
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ProductsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <param name="request">The Product creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Product details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a Product by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetProductRequest { Id = id };
            var validator = new GetProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetProductCommand>(request.Id);
            
            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<GetProductResponse>
                {
                    Success = true,
                    Message = "Product retrieved successfully",
                    Data = _mapper.Map<GetProductResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieves a Product by their ID
        /// </summary>
        /// <param name="_page">Page number for pagination (default: 1)</param>
        /// <param name="_size">Number of items per page(default: 10)</param>
        /// <param name="_order">Ordering of results (e.g., "Productname asc, email desc")</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product details if found</returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetProductResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListProduct(CancellationToken cancellationToken, int? _page = 1, int? _size = 10, string _order = "id asc")
        {
            var request = new ListProductRequest
            {
                Order = _order.ToLower(),
                Size = _size,
                Page = _page,
            };
            var validator = new ListProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<ListProductCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                var mappedResponse = _mapper.Map<PaginatedResponse<GetProductResponse>>(response);

                return Ok(new ApiResponseWithData<PaginatedResponse<GetProductResponse>>
                {
                    Success = true,
                    Message = "Product's retrieved successfully",
                    Data = mappedResponse
                });

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Updates a Product
        /// </summary>
        /// <param name="request">The Product update request</param>
        /// <param name="id">A Id that uniquely identifies the Updated Product in the system.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated Product details</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request, [FromRoute] int id, CancellationToken cancellationToken)
        {
            request.Id = id;
            var validator = new UpdateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = _mapper.Map<UpdateProductResponse>(response);

            return Ok(new ApiResponseWithData<UpdateProductResponse>
            {
                Success = true,
                Message = "Product updated successfully",
                Data = data
            });
        }

        /// <summary>
        /// Delete a Product by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product details if the Product is Deleted or Inactive</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeleteProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductRequest { Id = id };
            var validator = new DeleteProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteProductCommand>(request.Id);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<DeleteProductResponse>
                {
                    Success = true,
                    Message = "Product deleted successfully",
                    Data = _mapper.Map<DeleteProductResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
