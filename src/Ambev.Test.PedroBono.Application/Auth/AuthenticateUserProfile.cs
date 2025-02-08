﻿using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Auth
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
            CreateMap<User, AuthenticateUserResult>()
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
