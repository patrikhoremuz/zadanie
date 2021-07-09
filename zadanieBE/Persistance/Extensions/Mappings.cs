using System;
using System.Linq;
using zadanieBE.Application.Dtos;
using zadanieBE.Persistance.Models;

namespace zadanieBE.Persistance.Extensions
{
    public static class Mappings
    {
        public static EmployeeDto MapFromEntity(this Person entity){
            return new EmployeeDto{
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                DateOfBirth = entity.DateOfBirth,
                ValidFrom = entity.ValidFrom,
                Archived = entity.Archived,
                Salary = entity.Salary,
                Role = entity.PersonRoles.FirstOrDefault(x=>x.ValidFrom< DateTime.Now && x.ValidTo>DateTime.Now).RoleId,
                RoleName = entity.PersonRoles.FirstOrDefault(x=>x.ValidFrom< DateTime.Now && x.ValidTo>DateTime.Now).Role.RoleName,
                ValidTo = entity.ValidTo,
                Roles = entity.PersonRoles.Select(y=>new EmployeeRoles{
                    Id = y.Id,
                    RoleId = y.RoleId,
                    PersonId = y.PersonId,
                    ValidTo = y.ValidTo,
                    ValidFrom = y.ValidFrom,
                    RoleName = y.Role.RoleName
                })
            };
        }
    }
}
