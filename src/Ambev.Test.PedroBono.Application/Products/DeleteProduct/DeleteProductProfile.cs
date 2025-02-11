using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;

namespace Ambev.Test.PedroBono.Application.Products.DeleteProduct
{
    /// <summary>
    /// AutoMapper profile for authentication-related mappings
    /// </summary>
    public sealed class DeleteProductProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductProfile"/> class
        /// </summary>
        public DeleteProductProfile()
        {
            CreateMap<Product, DeleteProductResult>()
                .ForMember(result => result.Rate, opt => opt.MapFrom(product => product))
                ;
        }
    }
}
