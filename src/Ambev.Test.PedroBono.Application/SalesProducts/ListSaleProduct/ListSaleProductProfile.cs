using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListSaleProductProfile"/> class
    /// </summary>
    public class ListSaleProductProfile : Profile
    {
        public ListSaleProductProfile()
        {
            CreateMap<ListSaleProductCommand, PaginedFilter>();
            CreateMap<PaginatedResult<SaleProduct>, ListSaleProductResult>()
                .ForMember(result => result.Data, opt => opt.MapFrom(list => list));
        }
    }
}
