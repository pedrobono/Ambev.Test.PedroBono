﻿using Ambev.Test.PedroBono.Application.Users.CreateUser;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Users.CreateUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
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
            } catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
