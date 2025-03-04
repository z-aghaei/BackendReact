﻿using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{

    public sealed record GetUserListQuery :  IRequest<List<UserDto>>;
 

}
