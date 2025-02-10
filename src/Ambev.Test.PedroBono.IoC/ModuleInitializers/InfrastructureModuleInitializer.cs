using Ambev.Test.PedroBono.ORM;
using Ambev.Test.PedroBono.ORM.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.IoC.ModuleInitializers
{
    public class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<PostgresContext>());
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}
