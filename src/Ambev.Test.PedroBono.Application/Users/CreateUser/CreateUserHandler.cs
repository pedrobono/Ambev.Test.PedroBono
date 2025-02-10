using Ambev.Test.PedroBono.Common.Security;
using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.Test.PedroBono.Domain.Entities;

namespace Ambev.Test.PedroBono.Application.Users.CreateUser
{

    /// <summary>
    /// Handler for processing CreateUserCommand requests
    /// </summary>
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        /// Initializes a new instance of CreateUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for CreateUserCommand</param>
        public CreateUserHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Handles the CreateUserCommand request
        /// </summary>
        /// <param name="command">The CreateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user details</returns>
        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingUser = await _userRepository.GetByEmailOrUsernameAsync(command.Email, cancellationToken);

            if (existingUser != null)
                if (command.Email == existingUser.Email)
                    throw new InvalidOperationException($"User with email {command.Email} already exists");
            else
                    throw new InvalidOperationException($"User with UserName {command.Username} already exists");

            var user = _mapper.Map<User>(command);
            user.Password = _passwordHasher.HashPassword(command.Password);

            var createdUser = await _userRepository.CreateAsync(user, cancellationToken);
            command.Address.UserId = createdUser.Id;

            var address = _mapper.Map<Address>(command.Address);

            var createdAdress = await _addressRepository.CreateAsync(address);
            createdUser.Address = createdAdress;

            var result = _mapper.Map<CreateUserResult>(createdUser);
            
            return result;
        }
    }
}
