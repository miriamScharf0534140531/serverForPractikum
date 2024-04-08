using EM.Core.DTO;
using EM.Core.interfaces;
using EM.Core.models;
using Microsoft.AspNetCore.Mvc;
namespace EM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO employee)
        {
            bool res = await _employeeService.Add(employee);
            return res ? Ok() : BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            var res = await _employeeService.Update(id, employee);
            return res!=null ? Ok(employee) : BadRequest("invalid employee");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _employeeService.Delete(id);
            if (x == true)
                return Ok(x);
            return NotFound("Employee not found");
        }
        [HttpGet]
        public IActionResult GetAll() { 
            return Ok(_employeeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var x=await _employeeService.GetById(id);
            return x==null?NotFound("Employee not found"):Ok(x);
        }
        
    }
}
