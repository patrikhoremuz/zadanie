using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zadanieBE.Application.Dtos;
using zadanieBE.Persistance.Extensions;
using zadanieBE.Persistance.Interfaces;
using zadanieBE.Persistance.Models;

namespace zadanieBE.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly zadanieContext _context;

        public EmployeeRepository(zadanieContext context)
        {
            _context = context;
        }
        public void DeleteUser(int userId)
        {
            var entity =  _context.Persons.Where(x=>x.Id == userId).Include(x=>x.PersonRoles).FirstOrDefault();

            if(entity != null){
                _context.RemoveRange(entity.PersonRoles);
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void EditOrCreateUser(EmployeeDto employeeInfo)
        {
            var entity = _context.Persons.Include(x=>x.PersonRoles).Where(x=>x.Id == employeeInfo.Id).FirstOrDefault();

            if(entity != null){
                if(entity.PersonRoles.Where(x=>x.ValidFrom< DateTime.Now && x.ValidTo>DateTime.Now).FirstOrDefault().RoleId != employeeInfo.Role){
                    PersonRole roleEntity = new PersonRole{
                        PersonId = entity.Id,
                        ValidFrom = DateTime.Now,
                        RoleId = employeeInfo.Role,
                        ValidTo = DateTime.Now.AddYears(30)
                    };
                    _context.Add(roleEntity);
                    entity.PersonRoles.Where(x=>x.ValidFrom< DateTime.Now && x.ValidTo>DateTime.Now).FirstOrDefault().ValidTo = DateTime.Now;
                }
                entity.FirstName = employeeInfo.FirstName;
                entity.LastName = employeeInfo.LastName;
                entity.Address = employeeInfo.Address;
                entity.DateOfBirth = employeeInfo.DateOfBirth;
                entity.ValidFrom = employeeInfo.ValidFrom;
                entity.Archived = employeeInfo.Archived;
                entity.Salary = employeeInfo.Salary;
            }
            else{
                Person newEntity = new Person{
                    FirstName = employeeInfo.FirstName,
                    LastName = employeeInfo.LastName,
                    Address = employeeInfo.Address,
                    DateOfBirth = employeeInfo.DateOfBirth,
                    ValidFrom = employeeInfo.ValidFrom,
                    Archived = employeeInfo.Archived,
                    Salary = employeeInfo.Salary,
                };

                _context.Add(newEntity);
                _context.SaveChanges();

                 PersonRole roleEntity = new PersonRole{
                        PersonId = newEntity.Id,
                        ValidFrom = DateTime.Now,
                        RoleId = employeeInfo.Role,
                        ValidTo = DateTime.Now.AddYears(30)
                };
                _context.Add(roleEntity);
            }
            _context.SaveChanges();
        }

        public IEnumerable<EmployeeDto> GetFormerEmployees()
        {
            return _context.Persons
            .Include(x=>x.PersonRoles)
            .ThenInclude(x=>x.Role)
            .Where(x=>x.Archived)
            .Select(x=> x.MapFromEntity());
        }

        public IEnumerable<EmployeeDto> GetCurrentEmployees()
        {
            return _context.Persons
            .Include(x=>x.PersonRoles)
            .ThenInclude(x=>x.Role)
            .Where(x=>!x.Archived)
            .Select(x=> x.MapFromEntity());
        }

        public void ArchiveEmployee(int employeeId)
        {
            var entity = _context.Persons.Where(x=>x.Id == employeeId).FirstOrDefault();

            if(entity != null){
                entity.Archived = true;
                entity.ValidTo = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
