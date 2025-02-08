using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users
{
    /// <summary>
    /// AutoMapper profile for authentication-related mappings
    /// </summary>
    public class NameResultProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameResultProfile"/> class
        /// </summary>
        public NameResultProfile()
        {
            CreateMap<User, NameResult>()
                .ForMember(name => name.FirstName, opt => opt.MapFrom(user => user.FirstName))
                .ForMember(name => name.LastName, opt => opt.MapFrom(user => user.LastName));

        }
    }
}
