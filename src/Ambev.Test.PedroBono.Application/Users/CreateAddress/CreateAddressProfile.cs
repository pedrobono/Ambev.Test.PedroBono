using Ambev.Test.PedroBono.Application.Users.CreateUser;
using Ambev.Test.PedroBono.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.CreateAddress
{
    /// <summary>
    /// Profile for mapping between User entity and CreateUserResponse
    /// </summary>
    public class CreateAddressProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateUser operation
        /// </summary>
        public CreateAddressProfile()
        {
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<Address, CreateAddressResult>();
        }
    }
}
