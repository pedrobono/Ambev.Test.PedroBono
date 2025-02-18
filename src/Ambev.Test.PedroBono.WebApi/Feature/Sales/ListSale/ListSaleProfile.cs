using Ambev.Test.PedroBono.Application.Sales.ListSale;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.Sales.GetSale;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.ListSale
{
    /// <summary>
    /// Profile for mapping between Application and API ListSale responses
    /// </summary>
    public class ListSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSale feature
        /// </summary>
        public ListSaleProfile()
        {
            CreateMap<ListSaleRequest, ListSaleCommand>();

            CreateMap<ListSaleResult, PaginatedResponse<GetSaleResponse>>();


        }
    }
}