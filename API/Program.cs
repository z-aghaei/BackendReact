
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Infrastructure;
    

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


 builder.Services.AddInfrastructure();



//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//            .AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidateLifetime = true,
//                    ValidateIssuerSigningKey = true,
//                    ValidIssuer = "http://localhost:44319",
//                    ValidAudience = "http://localhost:44319",
//                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("123456"))
//                };
//            });

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowOrigin");



    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
