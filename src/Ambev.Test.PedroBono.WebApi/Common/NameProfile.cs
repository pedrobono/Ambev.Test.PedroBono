using Ambev.Test.PedroBono.Application.Common.Name;
using AutoMapper;

namespace Ambev.Test.PedroBono.WebApi.Common
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
            CreateMap<NameResult, NameResponse>();
        }
    }
}
