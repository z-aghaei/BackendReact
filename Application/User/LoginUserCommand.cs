﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public record LoginUserCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginModel 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
