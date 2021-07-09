using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zadanieBE.Application.Dtos;

namespace zadanieBE.Persistance.Interfaces
{
    public interface IRoleRepository
    {
        void CreateRole(string roleName);

        IEnumerable<RoleDto> GetRoles();
        void DeleteRole(int roleId);
    }
}
