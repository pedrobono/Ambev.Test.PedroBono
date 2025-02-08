using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser
{

    /// <summary>
    /// Profile for mapping between Application and API GetUser responses
    /// </summary>
    public class GetUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetUser feature
        /// </summary>
        public GetUserProfile()
        {
            CreateMap<GetUserRequest, GetUserCommand>();
            CreateMap<GetUserResult, GetUserResponse>();

        }
    }
}
