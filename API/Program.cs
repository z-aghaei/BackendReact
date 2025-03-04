
using Domain.Repositories;
using Infrastructure;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.User;
using API.Middleware;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });



//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
builder.Services.AddInfrastructure();
builder.Services.AddAutoMapper(typeof(Application.MappingProfile));

ConfigurationManager configuration = builder.Configuration;

    builder.Services.AddDbContext<AppDbContext>(ctx =>
    ctx.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

 builder.Services.AddScoped<IRepositoryUser, UserRepository>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin")); // Example policy for admin role
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));   // Example policy for user role
});

builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //Settings for token authentication
    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
}
      );

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowOrigin");



    app.UseHttpsRedirection();

    app.UseAuthentication();

   /// app.UseMiddleware<RoleAuthorizationMiddleware>();  // Add this middleware

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
