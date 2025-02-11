
using Ambev.Test.PedroBono.Application.Products.CreateRating;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Products.CreateRating
{
    /// <summary>
    /// Profile for mapping between Application and API rating responses
    /// </summary>
    public class CreateratingProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduct feature
        /// </summary>
        public CreateratingProfile()
        {
            CreateMap<CreateRatingRequest, CreateRatingCommand>();
            CreateMap<CreateRatingResult, CreateRatingResponse>();
        }
    }
}
