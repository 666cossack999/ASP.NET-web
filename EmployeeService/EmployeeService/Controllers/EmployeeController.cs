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
    public class EmployeeController : ControllerBase
    {
        #region Services

        private readonly ILogger<EmployeeController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeController(ILogger<EmployeeController> logger ,IOptions<LoggerOptions> loggerOptions, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            _logger.LogInformation("Сотрудник создан");
            return Ok(_employeeRepository.Create(new Employee
            {
                DepartmentId = request.DepartmentId,
                EmployeeTypeId = request.EmployeeTypeId,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic,
                Salary = request.Salary,
                Surname = request.Surname
            }));
        }

        [HttpGet("get/all")]
        public ActionResult<List<EmployeeDto>> GetAllEmployees()
        {
            _logger.LogInformation("Получены все сотрудники");
            return Ok(_employeeRepository.GetAll().Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary,
                Surname = employee.Surname
            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeDto> GetById([FromRoute] int id)
        {
            var employee = _employeeRepository.GetById(id);
            _logger.LogInformation($"Получен сотрудник №: {id}");
            return Ok(new EmployeeDto
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary,
                Surname = employee.Surname
            });

            
        }

        #endregion


    }
}
