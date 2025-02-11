using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.Domain.Common;
using Ambev.Test.PedroBono.ORM.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Ambev.Test.PedroBono.ORM.Common;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Common.Security;

namespace Ambev.Test.PedroBono.Application.Users.ListUser
{
    /// <summary>
    /// Handler for processing ListUserCommand requests
    /// </summary>
    public class ListUserHandler : IRequestHandler<ListUserCommand, ListUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ListUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Handles the ListUserCommand request
        /// </summary>
        /// <param name="request">The ListUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of user details if found</returns>
        public async Task<ListUserResult> Handle(ListUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var map = _mapper.Map<PaginedFilter>(request);

            var users = await _userRepository.ListPaginatedAsync(map, cancellationToken);

            return _mapper.Map<ListUserResult>(users);
        }
    }
}
