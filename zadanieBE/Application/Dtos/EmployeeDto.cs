using System;
using System.Collections.Generic;

namespace zadanieBE.Application.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }
        public double Salary { get; set; }
        public bool Archived { get; set; }
        public IEnumerable<EmployeeRoles> Roles { get; set; } 
    }
}
