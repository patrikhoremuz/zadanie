using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zadanieBE.Application.Dtos;
using zadanieBE.Application.Interfaces;
using zadanieBE.Persistance.Interfaces;

namespace zadanieBE.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public void DeleteUser(int userId)
        {
            _repository.DeleteUser(userId);
        }

        public void EditOrCreateUser(EmployeeDto employeeInfo)
        {
             _repository.EditOrCreateUser(employeeInfo);
        }

        public IEnumerable<EmployeeDto> GetFormerEmployees()
        {
            return _repository.GetFormerEmployees();
        }

        public IEnumerable<EmployeeDto> GetCurrentEmployees()
        {
            return _repository.GetCurrentEmployees();
        }

        public void ArchiveEmployee(int employeeId)
        {
            _repository.ArchiveEmployee(employeeId);
        }
    }
}
