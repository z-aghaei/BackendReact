using Domain;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Application.User
{
    public sealed class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRepositoryUser _repositoryUser;

        public LoginUserHandler(IRepositoryUser repositoryUser)
        {
           _repositoryUser = repositoryUser;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           var response = await _repositoryUser.GetAsync(request.Username,request.Password,cancellationToken);
            if (response == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            return GenerateJwtToken(request.Username,response.IsAdmin);
        }

        private string GenerateJwtToken(string username,bool IsAdmin)
        {
            var key = Encoding.ASCII.GetBytes("1fcd634c574a8cd88e64ddfa2d64535f");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,IsAdmin ? "Admin" :"User" )
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "http://localhost:44319",
                Audience = "http://localhost:44319"
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
