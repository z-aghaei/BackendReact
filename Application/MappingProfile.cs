﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
namespace Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.User, UserDto>();
            CreateMap<UserDto, Domain.User>();
        }
    }
}
