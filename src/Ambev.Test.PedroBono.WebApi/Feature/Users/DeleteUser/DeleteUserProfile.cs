using Ambev.Test.PedroBono.Application.Users.DeleteUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.DeleteUser;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.DeleteUser
{

    /// <summary>
    /// Profile for mapping between Application and API DeleteUser responses
    /// </summary>
    public class DeleteUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteUser feature
        /// </summary>
        public DeleteUserProfile()
        {
            CreateMap<DeleteUserRequest, DeleteUserCommand>();
            CreateMap<DeleteUserResult, DeleteUserResponse>()
                .ForMember(response => response.Address, opt => opt.MapFrom(result => result.Address));

        }
    }
}
