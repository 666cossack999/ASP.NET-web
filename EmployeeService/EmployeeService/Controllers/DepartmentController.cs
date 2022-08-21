using EmployeeService.Models.Requests;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController (IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateDepartmentRequest request)
        {
            return Ok(_departmentRepository.Create(new Models.Department
            {
                Description = request.Description
            }));
        }

        [HttpGet("get/all")]
        public IActionResult GetAllDepartments()
        {
            return Ok(_departmentRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(_departmentRepository.GetById(id));
        }
    }
}
