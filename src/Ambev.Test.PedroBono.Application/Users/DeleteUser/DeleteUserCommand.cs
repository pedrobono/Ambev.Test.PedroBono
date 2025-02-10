using MediatR;

namespace Ambev.Test.PedroBono.Application.Users.DeleteUser
{
    /// <summary>
    /// Command for creating a delete user.
    /// </summary>
    /// <remarks>
    /// This command is used to delete a user, 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="DeleteUserResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="DeleteUserCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class DeleteUserCommand : IRequest<DeleteUserResult>
    {
        /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of DeleteUserCommand
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
