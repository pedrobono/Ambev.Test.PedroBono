using Ambev.Test.PedroBono.Application;
using Ambev.Test.PedroBono.Common.Security;
using Ambev.Test.PedroBono.IoC;
using Ambev.Test.PedroBono.ORM;
using Ambev.Test.PedroBono.ORM.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => 
{
    o.CustomSchemaIds(id => id.FullName!.Replace("+", "-"));

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter your JWT token in this field",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT"
    };

    o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            []
        }
    };

    o.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddDbContext<PostgresContext>(options =>
                 options.UseNpgsql(
                    builder.Configuration.GetConnectionString("PostgresConnection"),
                    b => b.MigrationsAssembly("Ambev.Test.PedroBono.ORM")
                )
            );

builder.Services.AddAuthorization();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.RegisterDependencies();

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection(); 

app.UseAuthentication();
//app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
