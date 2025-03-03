using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
   // public  class UserDto(int Id, string UserName, string Password, string Name, string LastName, string Email, bool IsActive, bool IsAdmin);
    public class UserDto
    {
        public UserDto()
        {
          
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set;}


    }
}
