using Ambev.Test.PedroBono.Application.Users;
using Ambev.Test.PedroBono.Application.Users.UpdateUser;
using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Common;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.UpdateUser
{

    /// <summary>
    /// Profile for mapping between Application and API UpdateUser responses
    /// </summary>
    public class UpdateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateUser feature
        /// </summary>
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserRequest, UpdateUserCommand>()
                .ForMember(command => command.Status, opt => opt.MapFrom(request => Enum.Parse(typeof(UserStatus), request.Status, true)))
                .ForMember(command => command.Role, opt => opt.MapFrom(request => Enum.Parse(typeof(UserRole), request.Role, true)))
                .ForMember(command => command.FirstName, opt => opt.MapFrom(request =>  request.Name.FirstName))
                .ForMember(command => command.LastName, opt => opt.MapFrom(request =>  request.Name.LastName))
                .ForMember(command => command.Id, opt => opt.MapFrom(request =>  request.Id))
                ;
            CreateMap<UpdateUserResult, UpdateUserResponse>()
                .ForMember(response => response.Status, opt => opt.MapFrom(result => result.Status.ToString()))
                .ForMember(response => response.Role, opt => opt.MapFrom(result => result.Role.ToString()))
                .ForMember(response => response.Address, opt => opt.MapFrom(result => result.Address))
                
                ;
        }
    }
}
