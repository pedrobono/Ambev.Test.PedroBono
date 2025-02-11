using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Products.CreateRating
{
    /// <summary>
    /// AutoMapper profile for authentication-related mappings
    /// </summary>
    public class CreateRatingResultProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRatingResultProfile"/> class
        /// </summary>
        public CreateRatingResultProfile()
        {
            CreateMap<Product, CreateRatingResult>()
                .ForMember(name => name.Rate, opt => opt.MapFrom(product => product.Rate))
                .ForMember(name => name.Count, opt => opt.MapFrom(product => product.Count));

        }
    }
}
