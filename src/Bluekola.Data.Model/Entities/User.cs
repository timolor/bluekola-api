using System.Collections.Generic;
using Bluekola.Data.Model.Common;

namespace Bluekola.Data.Model.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Roles = new List<UserRole>();
        }

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
