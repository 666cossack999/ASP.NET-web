using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Options;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Authorize]
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

        [HttpPost("employee/create")]
        public ActionResult<int> Create(int departmentId, int employeeTypeId, string firstName, string surname, string patronumic, decimal salary)
        {
            _logger.LogInformation("Сотрудник создан");
            return Ok(_employeeRepository.Create(new Employee
            {
                DepartmentId = departmentId,
                EmployeeTypeId = employeeTypeId,
                FirstName = firstName,
                Patronymic = patronumic,
                Salary = salary,
                Surname = surname
            }));
        }

        [HttpGet("employee/all")]
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

        [HttpGet("employee/{id}")]
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

        [HttpDelete("employee/delete")]
        public IActionResult DeleteEmployeeTypes(int id)
        {
            _employeeRepository.Delete(id);
            _logger.LogInformation("Запись удалена");
            return Ok();
        }

        #endregion


    }
}
