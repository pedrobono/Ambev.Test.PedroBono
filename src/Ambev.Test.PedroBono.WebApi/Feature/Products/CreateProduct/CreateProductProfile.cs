using Ambev.Test.PedroBono.Application.Products.CreateProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Products.CreateProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.CreateProduct
{
    /// <summary>
    /// Profile for mapping between Application and API product responses
    /// </summary>
    public class CreateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduct feature
        /// </summary>
        public CreateProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(source => source.Rate.Rate))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(source => source.Rate.Count))
                ;
            CreateMap<CreateProductResult, CreateProductResponse>();
        }
    }
}
