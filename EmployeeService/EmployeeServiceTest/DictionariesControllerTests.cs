using EmployeeService.Controllers;
using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Options;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceTests
{
    public class DictionariesControllerTests
    {
        private readonly DictionariesController _dictionariesController;
        private readonly Mock<IEmployeeTypeRepository> _mockEmployeeTypeRepository;
        private readonly Mock<ILogger<DictionariesController>> _mockLogger;
        private readonly Mock<IOptions<LoggerOptions>> _mockOptions;
        private readonly Mock<IValidator<CreateEmployeeTypeRequest>> _mockValidator;


        public DictionariesControllerTests()
        {
            _mockEmployeeTypeRepository = new Mock<IEmployeeTypeRepository>();
            _dictionariesController = new DictionariesController(_mockLogger.Object, _mockOptions.Object, _mockEmployeeTypeRepository.Object, _mockValidator.Object);
        }

        #region Test Methods

        [Fact]
        public void GetAllEmployeeTypesTest()
        {
            // [1] Подготовка данных
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.GetAll()).Returns(new List<EmployeeType>());

            // [2] Исполнение тестируемого метода
            var result = _dictionariesController.GetAllEmployeeTypes();

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.GetAll(), Times.Once());

            // [3] Подготовка эталонного результата и проверка на валидность
            //Assert.IsAssignableFrom<ActionResult<IList<EmployeeTypeDto>>>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetByIdTest(int id)
        {
            var result = _dictionariesController.GetById(id);

            Assert.IsAssignableFrom<ActionResult<EmployeeTypeDto>>(result);
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        public void CreateEmployeeTypeTest(string description)
        {
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.Create(It.IsAny<EmployeeType>())).Verifiable();

            var result = _dictionariesController.CreateEmployeeType(description);

            _mockEmployeeTypeRepository.Verify(repository =>
                repository.Create(It.IsAny<EmployeeType>()), Times.Once);

            //Assert.IsAssignableFrom<ActionResult<int>>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteEmployeeTypeTest(int id)
        {
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.Delete(It.IsAny<int>())).Verifiable();

            var result = _dictionariesController.DeleteEmployeeType(id);

            _mockEmployeeTypeRepository.Verify(repository =>
                repository.Delete(It.IsAny<int>()), Times.Once);

            //Assert.IsAssignableFrom<IActionResult>(result);
        }
        #endregion
        
    }
}
