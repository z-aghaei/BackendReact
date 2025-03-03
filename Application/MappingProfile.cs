using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.User, User.UserDto>();
            CreateMap<User.UserDto, Domain.User>();
        }
    }
}
