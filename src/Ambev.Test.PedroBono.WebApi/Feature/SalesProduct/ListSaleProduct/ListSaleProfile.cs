using Ambev.Test.PedroBono.Application.SalesProducts.ListSaleProduct;
using Ambev.Test.PedroBono.WebApi.Common;
using Ambev.Test.PedroBono.WebApi.Feature.SaleProducts.ListSaleProduct;
using Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.GetSaleProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.ListSaleProduct
{
    /// <summary>
    /// Profile for mapping between Application and API ListSaleProduct responses
    /// </summary>
    public class ListSaleProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSaleProduct feature
        /// </summary>
        public ListSaleProductProfile()
        {
            CreateMap<ListSaleProductRequest, ListSaleProductCommand>();

            CreateMap<ListSaleProductResult, PaginatedResponse<GetSaleProductResponse>>();


        }
    }
}