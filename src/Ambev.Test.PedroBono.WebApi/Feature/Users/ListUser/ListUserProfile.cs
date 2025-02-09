using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Application.Users.ListUser;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Users.GetUser;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.ListUser
{
    /// <summary>
    /// Profile for mapping between Application and API ListUser responses
    /// </summary>
    public class ListUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetUser feature
        /// </summary>
        public ListUserProfile()
        {
            CreateMap<ListUserRequest, ListUserCommand>();
            CreateMap<ListUserResult, PaginatedList<GetUserResponse>>();

        }
    }
}
