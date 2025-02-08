using Ambev.Test.PedroBono.Application.Users;
using Ambev.Test.PedroBono.WebApi.Common;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users
{
    /// <summary>
    /// Profile for mapping between Application and API responses
    /// </summary>
    public class NameProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetUser feature
        /// </summary>
        public NameProfile()
        {
            CreateMap<NameResult, NameRequest>();
            CreateMap<NameRequest, NameResult>();
        }
    }
}
