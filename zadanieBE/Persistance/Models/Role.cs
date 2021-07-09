using System;
using System.Collections.Generic;

#nullable disable

namespace zadanieBE.Persistance.Models
{
    public partial class Role
    {
        public Role()
        {
            PersonRoles = new HashSet<PersonRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<PersonRole> PersonRoles { get; set; }
    }
}
