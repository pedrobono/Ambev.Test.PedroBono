using Ambev.Test.PedroBono.Application.Auth;
using Ambev.Test.PedroBono.Application.Users.CreateUser;
using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.DeleteUser
{
    /// <summary>
    /// AutoMapper profile for authentication-related mappings
    /// </summary>
    public sealed class DeleteUserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserProfile"/> class
        /// </summary>
        public DeleteUserProfile()
        {
            CreateMap<User, DeleteUserResult>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(result => result.Name, opt => opt.MapFrom(user => user))
                ;
        }
    }
}
