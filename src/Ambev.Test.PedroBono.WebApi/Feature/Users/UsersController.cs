using Ambev.Test.PedroBono.Application.Users.CreateUser;
using Ambev.Test.PedroBono.Application.Users.DeleteUser;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Application.Users.ListUser;
using Ambev.Test.PedroBono.Application.Users.UpdateUser;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Users.CreateAddress;
using Ambev.Test.PedroBono.WebApi.Feature.Users.CreateUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.DeleteUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.ListUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.UpdateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users
{
    /// <summary>
    /// Controller for authentication operations
    /// </summary>
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UsersController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="request">The user creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateUserCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateUserResponse>
            {
                Success = true,
                Message = "User created successfully",
                Data = _mapper.Map<CreateUserResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a user by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetUserRequest { Id = id };
            var validator = new GetUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetUserCommand>(request.Id);
            
            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<GetUserResponse>
                {
                    Success = true,
                    Message = "User retrieved successfully",
                    Data = _mapper.Map<GetUserResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Retrieves a user by their ID
        /// </summary>
        /// <param name="_page">Page number for pagination (default: 1)</param>
        /// <param name="_size">Number of items per page(default: 10)</param>
        /// <param name="_order">Ordering of results (e.g., "username asc, email desc")</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user details if found</returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetUserResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListUser(CancellationToken cancellationToken, int? _page = 1, int? _size = 10, string _order = "id asc")
        {
            var request = new ListUserRequest
            {
                Order = _order.ToLower(),
                Size = _size,
                Page = _page,
            };
            var validator = new ListUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<ListUserCommand>(request);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                var mappedResponse = _mapper.Map<PaginatedResponse<GetUserResponse>>(response);

                return Ok(new ApiResponseWithData<PaginatedResponse<GetUserResponse>>
                {
                    Success = true,
                    Message = "User's retrieved successfully",
                    Data = mappedResponse
                });

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="request">The user update request</param>
        /// <param name="id">A Id that uniquely identifies the Updated user in the system.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated user details</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, [FromRoute] int id, CancellationToken cancellationToken)
        {
            request.Id = id;
            var validator = new UpdateUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateUserCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var data = _mapper.Map<UpdateUserResponse>(response);

            return Ok(new ApiResponseWithData<UpdateUserResponse>
            {
                Success = true,
                Message = "User updated successfully",
                Data = data
            });
        }

        /// <summary>
        /// Delete a user by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user details if the User is Deleted or Inactive</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<DeleteUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteUserRequest { Id = id };
            var validator = new DeleteUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteUserCommand>(request.Id);

            try
            {
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<DeleteUserResponse>
                {
                    Success = true,
                    Message = "User deleted successfully",
                    Data = _mapper.Map<DeleteUserResponse>(response)
                });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
