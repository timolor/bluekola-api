﻿using System.Collections.Generic;

namespace Bluekola.Data.Model
{
    public class User
    {
        public User()
        {
            Roles = new List<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<UserRole> Roles { get; set; }
    }
}
