using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Options;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Services

        private readonly ILogger<DepartmentController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IValidator<CreateDepartmentRequest> _createDepartmentRequestValidator;

        #endregion

        #region Constructors

        public DepartmentController(ILogger<DepartmentController> logger, IOptions<LoggerOptions> loggerOptions, IDepartmentRepository departmentRepository, IValidator<CreateDepartmentRequest> createDepartmentRequestValidator)
        {
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
            _createDepartmentRequestValidator = createDepartmentRequestValidator;
        }

        #endregion

        #region Public Methods

        [HttpPost("department/create")]
        public ActionResult<int> Create(string description)
        {
            _logger.LogInformation("Департамент создан");
            return Ok(_departmentRepository.Create(new Department
            {
                Description = description
            })); ;
        }

        [HttpGet("department/all")]
        public ActionResult<List<DepartmentDto>> GetAllDepartments()
        {

            _logger.LogInformation("Все департаменты получены");
            return Ok(_departmentRepository.GetAll().Select(department => new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description
            }).ToList());
        }

        [HttpGet("department/{id}")]
        public ActionResult<DepartmentDto> GetById([FromRoute] int id)
        {
            var department = _departmentRepository.GetById(id);
            _logger.LogInformation($"Получен департамент №: {id}");
            return Ok(new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description
            });
        }

        [HttpDelete("department/delete")]
        public IActionResult DeleteEmployeeTypes(int id)
        {
            _departmentRepository.Delete(id);
            _logger.LogInformation("Запись удалена");
            return Ok();
        }

        #endregion

    }
}
