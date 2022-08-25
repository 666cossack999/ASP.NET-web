using EmployeeService.Models.Options;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        #region Services

        private readonly ILogger<DictionariesController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        #endregion

        #region Constructors

        public DictionariesController(ILogger<DictionariesController> logger, IOptions<LoggerOptions> loggerOptions, IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpGet("employee-types/all")]
        public IActionResult GetAllEmployeeTypes()
        {
            _logger.LogInformation("Получены все записи");
            return Ok(_employeeTypeRepository.GetAll());
        }

        #endregion


    }
}
