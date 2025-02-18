using Ambev.Test.PedroBono.Application.SalesProducts.DeleteSaleProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.SalesProduct.DelateSaleProduct
{
    public class DeleteSaleProductProfile : Profile
    {
        public DeleteSaleProductProfile()
        {
            CreateMap<DeleteSaleProductRequest, DeleteSaleProductCommand>();
            CreateMap<DeleteSaleProductResult, DeleteSaleProductResponse>();
        }
    }
}
