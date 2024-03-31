using EM.Core.DTO;
using EM.Core.interfaces;
using EM.Core.models;
using Microsoft.AspNetCore.Mvc;
namespace EM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmployeeDTO employee)
        {
            bool res = await _employeeService.Add(employee);
            return res ? Ok("ok") : BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            //return Ok(_employeeService.Update(id, employee));
            bool res = await _employeeService.Update(id, employee);
            return res ? Ok("ok") : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var x = await _employeeService.Delete(id);
            if (x == true)
                return Ok(x);
            return NotFound("Employee not found");
        }
        [HttpGet]
        public ActionResult<EmployeeDTO> GetAll() { 
            return Ok(_employeeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult>GetById(int id)
        {
            var x=await _employeeService.GetById(id);
            return x==null?NotFound("Employee not found"):Ok(x);
        }
        
    }
}
