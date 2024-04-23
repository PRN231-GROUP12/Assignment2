using System;
using System.Collections.Generic;
using PRN231_Group12.Assignment2.Repo.Entity;

namespace PRN231_Group12.Assignment2.Repo
{
    public partial class User
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Source { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public int? RoleId { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual Publisher? Publisher { get; set; }
        public virtual Role? Role { get; set; }
    }
}
