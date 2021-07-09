using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zadanieBE.Application.Dtos;

namespace zadanieBE.Application.Interfaces
{
    public interface IRoleService
    {
        void CreateRole(string roleName);

        IEnumerable<RoleDto> GetRoles();
        void DeleteRole(int roleId);
    }
}
