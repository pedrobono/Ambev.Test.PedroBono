using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.CreateUser
{

    /// <summary>
    /// Profile for mapping between User entity and CreateUserResponse
    /// </summary>
    public class CreateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateUser operation
        /// </summary>
        public CreateUserProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserResult>()
                .ForMember(result => result.Name, opt => opt.MapFrom(user => user))
                ;
        }
    }
}
