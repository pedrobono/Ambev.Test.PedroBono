using Ambev.Test.PedroBono.Application.Carts.DeleteCart;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.DeleteCart
{
    /// <summary>
    /// Profile for mapping between Application and API cart responses
    /// </summary>
    public class DeleteCartProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteCart feature
        /// </summary>
        public DeleteCartProfile()
        {
            CreateMap<DeleteCartRequest, DeleteCartCommand>();
            CreateMap<DeleteCartResult, DeleteCartResponse>();
        }
    }
}
