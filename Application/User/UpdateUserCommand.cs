using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public sealed record UpdateUserCommand(int id,string UserName,  string Name, string LastName, string Email, bool IsActive, bool IsAdmin) : IRequest;

}
