using Calendar.Models;
using Calendar.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    [Route("api/[controller]")]
    public class CriticalDateController : ControllerBase
    {
        private readonly ICriticalDateService _service;
        public CriticalDateController(ICriticalDateService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetDates(){
            var res = _service.GetMonthDates();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult CreateDate([FromBody] CriticalDate date){
            var res = _service.CreateCriticalDate(date);
            return res;
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteDate(int Id){
            var res = _service.DeleteCriticalDate(Id);
            return res;
        }

    }
}