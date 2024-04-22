using System;
using System.Collections.Generic;

namespace PRN231_Group12.Assignment2.Repo
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleDesc { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
