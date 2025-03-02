using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:44319",
                ValidAudience = "http://localhost:44319",
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("123456"))
            };
        });
            return services;
        }
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {

            var options = configuration.GetConnectionString("DataBaseConnectionString");
            services.AddDbContext<AppDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
