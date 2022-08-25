using EmployeeService.Data;
using EmployeeService.Models;
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

        private readonly ILogger<DepartmentController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(ILogger<DepartmentController> logger, IOptions<LoggerOptions> loggerOptions, IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateDepartmentRequest request)
        {
            _logger.LogInformation("Департамент создан");
            return Ok(_departmentRepository.Create(new Department
            {
                Description = request.Description
            }));
        }

        [HttpGet("get/all")]
        public ActionResult<List<DepartmentDto>> GetAllDepartments()
        {

            _logger.LogInformation("Все департаменты получены");
            return Ok(_departmentRepository.GetAll().Select(department => new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description
            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<DepartmentDto> GetById([FromRoute] Guid id)
        {
            var department = _departmentRepository.GetById(id);
            _logger.LogInformation($"Получен департамент №: {id}");
            return Ok(new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description
            });
        }

        #endregion

    }
}
