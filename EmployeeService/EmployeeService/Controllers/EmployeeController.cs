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

        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeController(IOptions<LoggerOptions> loggerOptions, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _loggerOptions = loggerOptions;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            return Ok(_employeeRepository.Create(new Models.Employee
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
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_employeeRepository.GetById(id));
        }

        #endregion


    }
}
