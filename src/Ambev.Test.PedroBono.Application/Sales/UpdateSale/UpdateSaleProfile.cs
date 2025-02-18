using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>()
                .ForMember(sale => sale.Products, opt => opt.Ignore())
                .ForMember(sale => sale.Id, opt => opt.MapFrom(command => command.SaleId));

            CreateMap<Sale, UpdateSaleResult>()
                .ForMember(result => result.Products, opt => opt.MapFrom(sale => sale.Products))
                .ForMember(result => result.SaleId, opt => opt.MapFrom(sale => sale.Id));
        }
    }
}
