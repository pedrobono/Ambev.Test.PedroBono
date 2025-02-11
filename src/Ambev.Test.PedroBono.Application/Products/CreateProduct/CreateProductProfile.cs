using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Products.CreateProduct
{
    /// <summary>
    /// Profile for mapping between Product entity and CreateProductResponse
    /// </summary>
    public class CreateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduct operation
        /// </summary>
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductResult>()
                .ForMember(result => result.Rate, opt => opt.MapFrom(product => product));
        }
    }
}
