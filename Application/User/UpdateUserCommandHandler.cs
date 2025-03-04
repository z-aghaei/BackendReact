using Application.DTO;
using AutoMapper;
using Domain;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private IRepositoryUser _repository;
        private IMapper _mapper;
        public UpdateUserCommandHandler(IRepositoryUser repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user=await _repository.GetById(request.id);
            var password = user.PasswordHash;
            if (user is Domain.User)
            {
                user=_mapper.Map<Domain.User>(request);
                user.PasswordHash= password;
                await _repository.UpdateAsync(user, cancellationToken);
            }
            
          
         // return user.Id;
        }
    
}
}
