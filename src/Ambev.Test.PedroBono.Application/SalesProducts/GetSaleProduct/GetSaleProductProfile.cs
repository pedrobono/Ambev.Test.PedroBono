using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.SalesProducts.GetSaleProduct
{
    public class GetSaleProductProfile : Profile
    {
        public GetSaleProductProfile()
        {
            CreateMap<GetSaleProductCommand, SaleProduct>();

            CreateMap<SaleProduct, GetSaleProductResult>()
                .ForMember(result => result.SaleProductId, opt => opt.MapFrom(saleProduct => saleProduct.Id))
                .ForMember(result => result.Quantity, opt => opt.MapFrom(saleProduct => saleProduct.Qty))
                .ForMember(result => result.TotalPrice, opt => opt.MapFrom(saleProduct => saleProduct.Total));
        }
    }
}
