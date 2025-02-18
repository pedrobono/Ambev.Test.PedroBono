using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.GetSale
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<GetSaleCommand, Sale>();
            
            CreateMap<Sale, GetSaleResult>()
                .ForMember(result => result.SaleId, opt => opt.MapFrom(sale => sale.Id))
                .ForMember(result => result.Products, opt => opt.MapFrom(sale => sale.Products));
        }
    }
}
