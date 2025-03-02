using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.User
            {
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                IsDeleted = false,
                IsActive=request.IsActive
               
            };

        }
    }
}
