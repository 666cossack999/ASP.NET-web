using EmployeeService.Models;
using EmployeeService.Data;

namespace EmployeeService.Services
{
    public interface IEmployeeTypeRepository : IRepository<EmployeeType, int> { }
}
