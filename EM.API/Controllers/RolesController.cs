using EM.Core.DTO;
using EM.Core.interfaces;
using EM.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleService.GetRoles());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _roleService.GetById(id);
            return x == null ? NotFound("Employee not found") : Ok(x);
        }
    }
}
