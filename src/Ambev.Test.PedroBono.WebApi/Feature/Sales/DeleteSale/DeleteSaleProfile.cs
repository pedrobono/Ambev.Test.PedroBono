using Ambev.Test.PedroBono.Application.Sales.DeleteSale;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Sales.DeleteSale
{
    /// <summary>
    /// Profile for mapping between Application and API delete sale-related requests and responses
    /// </summary>
    public class DeleteSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteSale feature
        /// </summary>
        public DeleteSaleProfile()
        {
            CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
            CreateMap<DeleteSaleResult, DeleteSaleResponse>();
        }
    }
}
