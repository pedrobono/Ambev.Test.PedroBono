using Ambev.Test.PedroBono.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCart
{
    /// <summary>
    /// Profile for mapping between Application and API cart responses
    /// </summary>
    public class CreateCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateCart feature
        /// </summary>
        public CreateCartProfile()
        {
            CreateMap<CreateCartRequest, CreateCartCommand>();
            CreateMap<CreateCartResult, CreateCartResponse>()
                .ForMember(response => response.Products, opt => opt.MapFrom(result => result.Producs));
        }
    }
}
