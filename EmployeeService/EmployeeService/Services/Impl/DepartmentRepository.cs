using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public int Create(Department data)
        {
            return 1;
            //throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            //throw new NotImplementedException();
        }

        public IList<Department> GetAll()
        {
            return new List<Department>();
            //throw new NotImplementedException();
        }

        public Department GetById(Guid id)
        {
            return new Department();
            //throw new NotImplementedException();
        }

        public void Update(Department data)
        {
            //throw new NotImplementedException();
        }
    }
}
