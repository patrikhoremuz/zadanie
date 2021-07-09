using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanieBE.Application.Dtos;
using zadanieBE.Application.Interfaces;
using zadanieBE.Persistance.Interfaces;
using zadanieBE.Persistance.Models;

namespace zadanieBE.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public void CreateRole(string roleName)
        {
            _repository.CreateRole(roleName);
        }

        public void DeleteRole(int roleId)
        {
            _repository.DeleteRole(roleId);
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            return _repository.GetRoles();
        }
    }
}
