using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.UpdateUser
{

    /// <summary>
    /// Profile for mapping between User entity and UpdateUserResponse
    /// </summary>
    public class UpdateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateUser operation
        /// </summary>
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserCommand, User>()
                .ForMember(result => result.Address, opt => opt.Ignore());
            CreateMap<User, UpdateUserResult>()
                .ForMember(result => result.Name, opt => opt.MapFrom(user => user))
                ;
        }
    }
}
