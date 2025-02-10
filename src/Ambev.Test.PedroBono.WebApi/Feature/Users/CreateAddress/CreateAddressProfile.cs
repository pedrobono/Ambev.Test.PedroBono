using Ambev.Test.PedroBono.Application.Users.CreateAddress;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.CreateAddress
{
    /// <summary>
    /// Profile for mapping between Application and API Address responses
    /// </summary>
    public class CreateAddressProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateUser feature
        /// </summary>
        public CreateAddressProfile()
        {
            CreateMap<CreateAddressRequest, CreateAddressCommand>()
                ;
            CreateMap<CreateAddressResult, CreateAddressResponse>()
                ;
        }
    }
}
