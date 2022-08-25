using EmployeeService.Models.Options;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Services

        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(IOptions<LoggerOptions> loggerOptions, IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
        }

        #endregion

        #region Public Methods

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

        #endregion

    }
}
