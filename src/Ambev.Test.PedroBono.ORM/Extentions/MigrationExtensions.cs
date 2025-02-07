using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.ORM.Extentions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using PostgresContext postgresContext = scope.ServiceProvider.GetService<PostgresContext>();

            //postgresContext.Database.EnsureCreated();


            postgresContext.Database.Migrate();
        }

    }
}
