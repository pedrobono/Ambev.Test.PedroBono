﻿using Ambev.Test.PedroBono.Application.Users;
using Ambev.Test.PedroBono.Application.Users.CreateUser;
using Ambev.Test.PedroBono.Domain.Enums;
using Ambev.Test.PedroBono.WebApi.Common;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.Test.PedroBono.WebApi.Feature.Users.CreateUser
{

    /// <summary>
    /// Profile for mapping between Application and API CreateUser responses
    /// </summary>
    public class CreateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateUser feature
        /// </summary>
        public CreateUserProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>()
                .ForMember(command => command.Status, opt => opt.MapFrom(request => Enum.Parse(typeof(UserStatus), request.Status, true)))
                .ForMember(command => command.Role, opt => opt.MapFrom(request => Enum.Parse(typeof(UserRole), request.Role, true)))
                .ForMember(command => command.FirstName, opt => opt.MapFrom(request =>  request.Name.FirstName))
                .ForMember(command => command.LastName, opt => opt.MapFrom(request =>  request.Name.LastName))
                ;
            CreateMap<CreateUserResult, CreateUserResponse>()
                .ForMember(response => response.Status, opt => opt.MapFrom(result => result.Status.ToString()))
                .ForMember(response => response.Role, opt => opt.MapFrom(result => result.Role.ToString()))
                .ForMember(response => response.Address, opt => opt.MapFrom(result => result.Address))

                ;
        }
    }
}
