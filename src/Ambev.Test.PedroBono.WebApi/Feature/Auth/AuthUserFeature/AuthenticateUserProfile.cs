using Ambev.Test.PedroBono.Application.Auth;
using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Auth.AuthUserFeature
{
    /// <summary>
    /// AutoMapper profile for authentication-related mappings
    /// </summary>
    public sealed class AuthenticateUserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateUserProfile"/> class
        /// </summary>
        public AuthenticateUserProfile()
        {
            CreateMap<User, AuthenticateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
            CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();
        }
    }
}
