using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Sales.ListSale
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListSaleProfile"/> class
    /// </summary>
    public class ListSaleProfile : Profile
    {
        public ListSaleProfile()
        {
            CreateMap<ListSaleCommand, PaginedFilter>();
            CreateMap<PaginatedResult<Sale>, ListSaleResult>()
                .ForMember(result => result.Data, opt => opt.MapFrom(list => list));
        }
    }
}
