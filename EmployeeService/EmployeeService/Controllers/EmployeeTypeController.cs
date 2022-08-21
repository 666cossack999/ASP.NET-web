using EmployeeService.Models.Requests;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        EmployeeTypeController(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeTypeRequest request)
        {
            return Ok(_employeeTypeRepository.Create(new Models.EmployeeType
            {
                Description = request.Description
            }));
        }

        [HttpGet("get/all")]
        public IActionResult GetAllEmployeeType()
        {
            return Ok(_employeeTypeRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_employeeTypeRepository.GetById(id));
        }
    }
}
