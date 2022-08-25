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
    public class EmployeeTypeController : ControllerBase
    {
        #region Services

        private readonly ILogger<EmployeeTypeController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        #endregion

        #region Constructors

        public EmployeeTypeController(ILogger<EmployeeTypeController> logger ,IOptions<LoggerOptions> loggerOptions, IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeTypeRequest request)
        {
            _logger.LogInformation("Тип сотрудника создан");
            return Ok(_employeeTypeRepository.Create(new EmployeeType
            {
                Description = request.Description
            }));
        }

        [HttpGet("get/all")]
        public ActionResult<List<EmployeeTypeDto>> GetAllEmployeeType()
        {
            _logger.LogInformation("Получены все типы сотрудников");
            return Ok(_employeeTypeRepository.GetAll().Select(employeeType => new EmployeeTypeDto
            {
                Id = employeeType.Id,
                Description = employeeType.Description
            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeTypeDto> GetById([FromRoute] int id)
        {
            var employeeType = _employeeTypeRepository.GetById(id);
            _logger.LogInformation($"Получен тип сотрудника №: {id}");
            return Ok(new EmployeeTypeDto
            {
                Id = employeeType.Id,
                Description = employeeType.Description
            });
        }

        #endregion


    }
}
