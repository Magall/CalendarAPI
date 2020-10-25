using Calendar.Models;
using Calendar.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }
       [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_service.GetDepartments());
        }
        [HttpGet("{Name}")]     
        public IActionResult GetDepartment(string Name){
            return Ok(_service.GetDepartmentByName(Name));
        }
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department dep){
            return _service.CreateDepartment(dep);
        }
        [HttpDelete("{Name}")]
        public IActionResult DeleteDepartment(string name){
            return _service.DeleteDepartment(name);
        }


    }
}