using MediatR;

namespace Ambev.Test.PedroBono.Application.Users.GetUser
{
    /// <summary>
    /// Command for creating a new user.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a user, 
    /// including username, password, phone number, email, status, and role. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateUserResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateUserCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class GetUserCommand : IRequest<GetUserResult>
    {
        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of GetUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        public GetUserCommand(int id)
        {
            Id = id;
        }
    }
}
