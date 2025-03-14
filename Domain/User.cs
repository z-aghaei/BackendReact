﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDateTime { get; set; }

        public int CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? DeleteUserId { get; set; }
        public DateTime? DeleteUserDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool IsAdmin { get; set; }
    }
}
