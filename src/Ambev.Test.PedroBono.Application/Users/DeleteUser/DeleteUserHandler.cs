using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.Test.PedroBono.Application.Users.DeleteUser
{
    /// <summary>
    /// Handler for processing DeleteUserCommand requests
    /// </summary>
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of DeleteUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the DeleteUserCommand request
        /// </summary>
        /// <param name="request">The DeleteUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user details if found</returns>
        public async Task<DeleteUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteUserValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            var ok = await _userRepository.DeleteAsync(request.Id, cancellationToken);

            if(!ok)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            return _mapper.Map<DeleteUserResult>(user);
        }
    }
}
