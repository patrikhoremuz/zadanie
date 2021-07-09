using System;
using System.Collections.Generic;

#nullable disable

namespace zadanieBE.Persistance.Models
{
    public partial class PersonRole
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
    }
}
