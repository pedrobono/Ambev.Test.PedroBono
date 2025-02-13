using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Carts.ListCart
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListCartProfile"/> class
    /// </summary>
    public class ListCartProfile : Profile
    {
        public ListCartProfile()
        {
            CreateMap<ListCartCommand, PaginedFilter>();
            CreateMap<PaginatedResult<Cart>, ListCartResult>()
                .ForMember(result => result.Data, opt => opt.MapFrom(list => list));
        }
    }
}
