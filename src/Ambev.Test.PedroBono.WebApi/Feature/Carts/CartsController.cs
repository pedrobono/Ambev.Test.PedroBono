using Ambev.Test.PedroBono.Application.Carts.CreateCart;
using Ambev.Test.PedroBono.Application.Carts.DeleteCart;
using Ambev.Test.PedroBono.Application.Carts.GetCart;
using Ambev.Test.PedroBono.Application.Carts.ListCart;
using Ambev.Test.PedroBono.Application.Carts.UpdateCart;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCart;
using Ambev.Test.PedroBono.WebApi.Feature.Carts.DeleteCart;
using Ambev.Test.PedroBono.WebApi.Feature.Carts.GetCart;
using Ambev.Test.PedroBono.WebApi.Feature.Carts.ListCart;
using Ambev.Test.PedroBono.WebApi.Feature.Carts.UpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts
{
    /// <summary>
    /// Controller for authentication operations
    /// </summary>
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CartsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CartsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new Cart
        /// </summary>
        /// <param name="request">The Cart creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Cart details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
            {
                Success = true,
                Message = "Cart created successfully",
                Data = _mapper.Map<CreateCartResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a Cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Cart details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCart([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetCartRequest { Id = id };
            var validator = new GetCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetCartCommand>(request.Id);
            
            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<GetCartResponse>
                {
                    Success = true,
                    Message = "Cart retrieved successfully",
                    Data = _mapper.Map<GetCartResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieves a Cart by their ID
        /// </summary>
        /// <param name="_page">Page number for pagination (default: 1)</param>
        /// <param name="_size">Number of items per page(default: 10)</param>
        /// <param name="_order">Ordering of results (e.g., "Cartname asc, email desc")</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Cart details if found</returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetCartResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListCart(CancellationToken cancellationToken, int? _page = 1, int? _size = 10, string _order = "id asc")
        {
            var request = new ListCartRequest
            {
                Order = _order.ToLower(),
                Size = _size,
                Page = _page,
            };
            var validator = new ListCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<ListCartCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                var mappedResponse = _mapper.Map<PaginatedResponse<GetCartResponse>>(response);

                return Ok(new ApiResponseWithData<PaginatedResponse<GetCartResponse>>
                {
                    Success = true,
                    Message = "Cart's retrieved successfully",
                    Data = mappedResponse
                });

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Updates a Cart
        /// </summary>
        /// <param name="request">The Cart update request</param>
        /// <param name="id">A Id that uniquely identifies the Updated Cart in the system.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated Cart details</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartRequest request, [FromRoute] int id, CancellationToken cancellationToken)
        {
            request.Id = id;
            var validator = new UpdateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = _mapper.Map<UpdateCartResponse>(response);

            return Ok(new ApiResponseWithData<UpdateCartResponse>
            {
                Success = true,
                Message = "Cart updated successfully",
                Data = data
            });
        }

        /// <summary>
        /// Delete a Cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Cart details if the Cart is Deleted or Inactive</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeleteCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteCartRequest { Id = id };
            var validator = new DeleteCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteCartCommand>(request.Id);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<DeleteCartResponse>
                {
                    Success = response.Result,
                    Message = response.Message,
                    Data = null
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
