using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Products.UpdateProduct
{

    /// <summary>
    /// Profile for mapping between Product entity and UpdateProductResponse
    /// </summary>
    public class UpdateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateProduct operation
        /// </summary>
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, UpdateProductResult>()
                .ForMember(result => result.Rate, opt => opt.MapFrom(product => product))
                ;
        }
    }
}
