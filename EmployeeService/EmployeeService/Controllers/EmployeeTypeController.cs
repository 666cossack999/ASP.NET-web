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

        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        #endregion

        #region Constructors

        EmployeeTypeController(IOptions<LoggerOptions> loggerOptions, IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _loggerOptions = loggerOptions;
        }

        #endregion

        #region Public Methods

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

        #endregion


    }
}
