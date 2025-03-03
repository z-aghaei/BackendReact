using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private IRepositoryUser _repository;
        private IMapper _mapper;
        public GetUserQueryHandler(IRepositoryUser repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var result=await _repository.GetAll();

            var userDto =_mapper.Map<List<UserDto>>(result);

            return userDto;
        }
    }


}
