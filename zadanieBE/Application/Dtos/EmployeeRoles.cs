using System;

namespace zadanieBE.Application.Dtos
{
    public class EmployeeRoles
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string RoleName { get; set; }
    }
}
