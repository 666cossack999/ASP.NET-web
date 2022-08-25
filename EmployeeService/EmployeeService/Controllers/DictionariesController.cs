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

        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        #endregion

        #region Constructors

        public DictionariesController(IOptions<LoggerOptions> loggerOptions, IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _loggerOptions = loggerOptions;
        }

        #endregion

        #region Public Methods

        [HttpGet("employee-types/all")]
        public IActionResult GetAllEmployeeTypes()
        {
            return Ok(_employeeTypeRepository.GetAll());
        }

        #endregion


    }
}
