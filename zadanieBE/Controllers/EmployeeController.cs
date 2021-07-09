using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zadanieBE.Application.Dtos;
using zadanieBE.Application.Interfaces;

namespace zadanieBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee([FromRoute] int employeeId)
        {
            _service.DeleteUser(employeeId);
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateOrUprdateEmployee([FromBody]EmployeeDto employeeInfo){
            _service.EditOrCreateUser(employeeInfo);
            return Ok();
        }

        [HttpPut("archive/{employeeId}")]
        public IActionResult ArchiveEmployee([FromRoute] int employeeId){
            _service.ArchiveEmployee(employeeId);
            return Ok();
        }

        [HttpGet("current")]
        public IActionResult GetCurrentEmployees(){
            return Ok(_service.GetCurrentEmployees());
        }

        [HttpGet("former")]
        public IActionResult GetFormerEmployees(){
            return Ok(_service.GetFormerEmployees());
        }
    }
}
