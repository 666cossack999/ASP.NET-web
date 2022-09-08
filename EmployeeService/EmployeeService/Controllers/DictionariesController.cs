using EmployeeService.Models;
using EmployeeService.Models.Options;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        #region Services

        private readonly ILogger<DictionariesController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        private readonly IValidator<CreateEmployeeTypeRequest> _createEmployeeTypeRequest;

        #endregion

        #region Constructors

        public DictionariesController(ILogger<DictionariesController> logger, IOptions<LoggerOptions> loggerOptions, IEmployeeTypeRepository employeeTypeRepository, IValidator<CreateEmployeeTypeRequest> createEmployeeTypeRequest)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
            _createEmployeeTypeRequest = createEmployeeTypeRequest;
        }

        #endregion

        #region Public Methods

        [HttpGet("employee-types/all")]
        public ActionResult<IList<EmployeeTypeDto>> GetAllEmployeeTypes()
        {
            _logger.LogInformation("Получены все записи");
            return Ok(_employeeTypeRepository.GetAll().Select(et =>
            new EmployeeTypeDto
            {
                Id = et.Id,
                Description = et.Description
            }).ToList());
        }

        [HttpGet("employee-types/{id}")]
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

        [HttpPost("employee-types/create")]
        public ActionResult<int> CreateEmployeeType(string description)
        {
            _logger.LogInformation("Добавлена запись");
            return Ok(_employeeTypeRepository.Create(new Data.EmployeeType
            {
                Description = description
            }));
        }


        [HttpDelete("employee-types/delete")]
        public IActionResult DeleteEmployeeType(int id)
        {
            _employeeTypeRepository.Delete(id);
            _logger.LogInformation("Запись удалена");
            return Ok();
        }
        #endregion


    }
}
