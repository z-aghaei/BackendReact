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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private IRepositoryUser _repository;
        private IMapper _mapper;
        public DeleteUserCommandHandler(IRepositoryUser repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.id);

            if (user is Domain.User)
            {

                await _repository.DeleteAsync(user, cancellationToken);
            }

        }
    }
}
