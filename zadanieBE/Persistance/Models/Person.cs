using System;
using System.Collections.Generic;

#nullable disable

namespace zadanieBE.Persistance.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonRoles = new HashSet<PersonRole>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ValidFrom { get; set; }
        public double Salary { get; set; }
        public bool Archived { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual ICollection<PersonRole> PersonRoles { get; set; }
    }
}
