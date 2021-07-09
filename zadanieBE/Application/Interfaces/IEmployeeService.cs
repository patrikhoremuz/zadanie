using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zadanieBE.Application.Dtos;

namespace zadanieBE.Application.Interfaces
{
    public interface IEmployeeService
    {
        void DeleteUser(int userId);
        void EditOrCreateUser(EmployeeDto employeeInfo);
        IEnumerable<EmployeeDto> GetCurrentEmployees();
        IEnumerable<EmployeeDto> GetFormerEmployees();
        void ArchiveEmployee(int employeeId);
    }
}
