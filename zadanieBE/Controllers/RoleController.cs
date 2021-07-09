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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpPost("{roleName}")]
        public IActionResult CreateRole(string roleName){
            _service.CreateRole(roleName);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetRoles(){
            return Ok(_service.GetRoles());
        }

        [HttpDelete("{roleId}")]
        public IActionResult DeleteRole(int roleId){
            _service.DeleteRole(roleId);
            return Ok();
        }
    }
}
