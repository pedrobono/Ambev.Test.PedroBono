using Ambev.Test.PedroBono.Common.Security;
using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;

namespace Ambev.Test.PedroBono.Application.Users.UpdateUser
{

    /// <summary>
    /// Handler for processing UpdateUserCommand requests
    /// </summary>
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        /// Initializes a new instance of UpdateUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for UpdateUserCommand</param>
        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Handles the UpdateUserCommand request
        /// </summary>
        /// <param name="command">The UpdateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated user details</returns>
        public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingUser = await _userRepository.GetByEmailOrUsernameAsync(command.Email, cancellationToken);
            ValidateExistingUser(command, existingUser);

            existingUser = await _userRepository.GetByEmailOrUsernameAsync(command.Username, cancellationToken);
            ValidateExistingUser(command, existingUser);


            var user = _mapper.Map<User>(command);
            user.Password = _passwordHasher.HashPassword(command.Password);

            var UpdatedUser = await _userRepository.UpdateAsync(user, cancellationToken);
            var result = _mapper.Map<UpdateUserResult>(UpdatedUser);
            return result;
        }

        private static void ValidateExistingUser(UpdateUserCommand command, User? existingUser)
        {
            if (existingUser != null && command.Id != existingUser.Id)
                if (command.Email == existingUser.Email)
                    throw new InvalidOperationException($"User with email {command.Email} already exists");
                else
                    throw new InvalidOperationException($"User with UserName {command.Username} already exists");
        }
    }
}
