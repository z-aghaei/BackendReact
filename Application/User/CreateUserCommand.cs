using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public sealed record CreateUserCommand(string UserName, string Password, string Name, string LastName, string Email,bool IsActive,bool IsAdmin):IRequest<int>;
   //public class CreateUserCommand:IRequest<int>
   // {
   //     public CreateUserCommand(string userName, string password, string name, string lastName, string email, bool isActive, bool isAdmin)
   //     {
   //         UserName = userName;
   //         Password = password;
   //         Name = name;
   //         LastName = lastName;
   //         Email = email;
   //         IsActive = isActive;

   //         IsAdmin = isAdmin;

   //     }

   //     public string  UserName { get; set; }
   //     public string Password { get; set; }
   //     public string Name { get; set; }
   //     public string LastName { get; set; }
   //     public string Email { get; set; }

   //     public bool IsActive { get; set; }

   //     public bool IsAdmin { get; set; }
   // }


}
