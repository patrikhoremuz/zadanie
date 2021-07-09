using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zadanieBE.Application.Dtos;
using zadanieBE.Persistance.Interfaces;
using zadanieBE.Persistance.Models;

namespace zadanieBE.Persistance.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly zadanieContext _context;

        public RoleRepository(zadanieContext context)
        {
            _context = context;
        }
        public void CreateRole(string roleName)
        {
            Role entity = new Role{
                RoleName = roleName
            };

            _context.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteRole(int roleId)
        {
            var entity = _context.Roles.Where(x=>x.Id == roleId).FirstOrDefault();

            if(entity!=null){
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            return _context.Roles.Select(x=> new RoleDto{
                Id  = x.Id,
                RoleName = x.RoleName
            });
        }
    }
}
