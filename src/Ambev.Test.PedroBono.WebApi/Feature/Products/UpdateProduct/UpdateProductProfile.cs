using Ambev.Test.PedroBono.Application.Products.UpdateProduct;
using Ambev.Test.PedroBono.WebApi.Feature.Products.UpdateProduct;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.UpdateProduct
{
    /// <summary>
    /// Profile for mapping between Application and API product responses
    /// </summary>
    public class UpdateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateProduct feature
        /// </summary>
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(source => source.Rate.Rate))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(source => source.Rate.Count))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                ;
            CreateMap<UpdateProductResult, UpdateProductResponse>();
        }
    }
}
