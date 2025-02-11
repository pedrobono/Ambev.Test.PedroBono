using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Products.GetProduct
{
    /// <summary>
    /// AutoMapper profile for authentication-related mappings
    /// </summary>
    public sealed class GetProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductProfile"/> class
        /// </summary>
        public GetProductProfile()
        {
            CreateMap<Product, GetProductResult>()
                .ForMember(result => result.Rate, opt => opt.MapFrom(product => product))
                ;
        }
    }
}
