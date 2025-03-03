using Domain.Repositories;
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
        private IRepositoryUser _repository;
        public CreateUserCommandHandler(IRepositoryUser repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.User
            {
                UserName = request.UserName,
                PasswordHash = request.Password,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                IsDeleted = false,
                IsActive=request.IsActive
               
            };
            await _repository.AddAsync(user,cancellationToken);
            return user.Id;
        }
    }
}
