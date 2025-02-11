using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Products.ListProduct
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListProductProfile"/> class
    /// </summary>
    public class ListProductProfile : Profile
    {
        public ListProductProfile()
        {
            CreateMap<ListProductCommand, PaginedFilter>();
            CreateMap<PaginatedResult<Product>, ListProductResult>()
                .ForMember(result => result.Data, opt => opt.MapFrom(list => list));
        }
    }
}
