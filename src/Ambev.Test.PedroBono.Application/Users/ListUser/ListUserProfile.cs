using Ambev.Test.PedroBono.Application.Common.Pagination;
using Ambev.Test.PedroBono.Application.Users.CreateUser;
using Ambev.Test.PedroBono.Application.Users.GetUser;
using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.ListUser
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListUserProfile"/> class
    /// </summary>
    public class ListUserProfile : Profile
    {
        public ListUserProfile()
        {
            CreateMap<ListUserCommand, PaginedFilter>();
            CreateMap<PaginatedResult<User>, ListUserResult>()
                .ForMember(result => result.Data, opt => opt.MapFrom(list => list));
        }
    }
}
