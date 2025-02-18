using Ambev.Test.PedroBono.Application.Sales.CreateSale;
using Ambev.Test.PedroBono.Application.Sales.DeleteSale;
using Ambev.Test.PedroBono.Application.Sales.GetSale;
using Ambev.Test.PedroBono.Application.Sales.ListSale;
using Ambev.Test.PedroBono.Application.Sales.UpdateSale;
using Ambev.Test.PedroBono.Application.SalesProducts.CreateSaleProduct;
using Ambev.Test.PedroBono.Application.SalesProducts.DeleteSaleProduct;
using Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct;
using Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct;
using Ambev.Test.PedroBono.Application.SalesProducts.UpdateSaleProduct;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.SaleProducts.ListSaleProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.CreateSale;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.DeleteSale;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.GetSale;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.ListSale;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.UpdateSale;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.CreateSaleProduct;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.DelateSaleProduct;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.UpdateSaleProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales
{
    /// <summary>
    /// Controller for authentication operations
    /// </summary>
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of SalesController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new Sale
        /// </summary>
        /// <param name="request">The Sale creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Sale details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var userIdString = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized("User ID not found.");

            request.UserId = userId;
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(response)
            });
        }

        /// <summary>
        /// Creates a new Sale
        /// </summary>
        /// <param name="idSale">The id of The sale to create a new product into</param>
        /// <param name="request">The SaleProduct creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Sale details</returns>
        [HttpPost("{idSale}/Products")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSaleProduct([FromRoute] int idSale, [FromBody] CreateSaleProductRequest request, CancellationToken cancellationToken)
        {
            request.SaleId = idSale;
            var validator = new CreateSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleProductResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleProductResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a Sale by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSale([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetSaleRequest { SaleId = id };
            var validator = new GetSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<GetSaleResponse>
                {
                    Success = true,
                    Message = "Sale retrieved successfully",
                    Data = _mapper.Map<GetSaleResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieves the Sale product by their sale product ID and sale id
        /// </summary>
        /// <param name="idSaleProduct">The unique identifier od the SaleProduct</param>
        /// <param name="idSale">The unique identifier of the Sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale Product details if found</returns>
        [HttpGet("{idSale}/Products/{idSaleProduct}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaleProduct([FromRoute] int idSale, [FromRoute] int idSaleProduct, CancellationToken cancellationToken)
        {
            var request = new GetSaleProductRequest { SaleProductId = idSaleProduct, SaleId = idSale };
            var validator = new GetSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleProductCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<GetSaleProductResponse>
                {
                    Success = true,
                    Message = "Sale Product retrieved successfully",
                    Data = _mapper.Map<GetSaleProductResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieves all sales
        /// </summary>
        /// <param name="_page">Page number for pagination (default: 1)</param>
        /// <param name="_size">Number of items per page(default: 10)</param>
        /// <param name="_order">Ordering of results (e.g., "Salename asc, email desc")</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale details if found</returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetSaleResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListSale(CancellationToken cancellationToken, int? _page = 1, int? _size = 10, string _order = "id asc")
        {
            var request = new ListSaleRequest
            {
                Order = _order.ToLower(),
                Size = _size,
                Page = _page,
            };
            var validator = new ListSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<ListSaleCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                var mappedResponse = _mapper.Map<PaginatedResponse<GetSaleResponse>>(response);

                return Ok(new ApiResponseWithData<PaginatedResponse<GetSaleResponse>>
                {
                    Success = true,
                    Message = "Sale's retrieved successfully",
                    Data = mappedResponse
                });

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieves all sales Products from a Sale
        /// </summary>
        /// <param name="idSale">The Id of a Sale</param>
        /// <param name="_page">Page number for pagination (default: 1)</param>
        /// <param name="_size">Number of items per page(default: 10)</param>
        /// <param name="_order">Ordering of results (e.g., "Salename asc, email desc")</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale details if found</returns>
        [HttpGet("{idSale}/Products")]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetSaleProductResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListSaleProducts([FromRoute] int idSale, CancellationToken cancellationToken, int? _page = 1, int? _size = 10, string _order = "id asc")
        {
            var request = new ListSaleProductRequest
            {
                Order = _order.ToLower(),
                Size = _size,
                Page = _page,
                SaleId = idSale
            };
            var validator = new ListSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<ListSaleProductCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                var mappedResponse = _mapper.Map<PaginatedResponse<GetSaleProductResponse>>(response);

                return Ok(new ApiResponseWithData<PaginatedResponse<GetSaleProductResponse>>
                {
                    Success = true,
                    Message = "Sale Products's retrieved successfully",
                    Data = mappedResponse
                });

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Updates a Sale
        /// </summary>
        /// <param name="request">The Sale update request</param>
        /// <param name="id">A Id that uniquely identifies the Updated Sale in the system.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated Sale details</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSale([FromBody] UpdateSaleRequest request, [FromRoute] int id, CancellationToken cancellationToken)
        {
            var userIdString = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized("User ID not found.");

            request.UserId = userId; 
            request.SaleId = id;
            var validator = new UpdateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = _mapper.Map<UpdateSaleResponse>(response);

            return Ok(new ApiResponseWithData<UpdateSaleResponse>
            {
                Success = true,
                Message = "Sale updated successfully",
                Data = data
            });
        }

        /// <summary>
        /// Updates a Sale Product
        /// </summary>
        /// <param name="request">The Sale Product update request</param>
        /// <param name="idSale">A Id that uniquely identifies the Sale in the system.</param>
        /// <param name="idSaleProduct">A Id that uniquely identifies the Sale in the system.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated Sale details</returns>
        [HttpPut("{idSale}/Products/{idSaleProduct}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSaleProduct([FromBody] UpdateSaleProductRequest request, [FromRoute] int idSale, [FromRoute] int idSaleProduct, CancellationToken cancellationToken)
        {
            request.SaleId = idSale;
            request.SaleProductId = idSaleProduct;
            var validator = new UpdateSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateSaleProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = _mapper.Map<UpdateSaleProductResponse>(response);

            return Ok(new ApiResponseWithData<UpdateSaleProductResponse>
            {
                Success = true,
                Message = "Sale product updated successfully",
                Data = data
            });
        }

        /// <summary>
        /// Delete a Sale by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale details if the Sale is Deleted or Inactive</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeleteSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSale([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleRequest { SaleId = id };
            var validator = new DeleteSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<DeleteSaleResponse>
                {
                    Success = true,
                    Message = "Sale deleted successfully",
                    Data = _mapper.Map<DeleteSaleResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Delete a Sale Product by their ID and Sale
        /// </summary>
        /// <param name="idSale">The unique identifier of the Sale</param>
        /// <param name="idSaleProduct">The unique identifier of the SaleProduct relationship</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale details if the Sale is Deleted or Inactive</returns>
        [HttpDelete("{idSale}/Products/{idSaleProduct}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeleteSaleProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSaleProduct([FromRoute] int idSale, [FromRoute] int idSaleProduct, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleProductRequest { SaleId = idSale, SaleProductId = idSaleProduct };
            var validator = new DeleteSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleProductCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<DeleteSaleProductResponse>
                {
                    Success = true,
                    Message = "Sale product deleted successfully",
                    Data = _mapper.Map<DeleteSaleProductResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
