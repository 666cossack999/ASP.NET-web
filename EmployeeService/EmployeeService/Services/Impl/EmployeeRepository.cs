using EmployeeService.Data;

namespace EmployeeService.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {

        #region Services

        private readonly EmployeeServiceDbContext _context;

        #endregion


        #region Constructor

        public EmployeeRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        #endregion

        public int Create(Employee data)
        {
            _context.Employees.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public void Delete(int id)
        {
            Employee employee = GetById(id);
            if (employee == null)
                throw new Exception("Employee не найден");

            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public IList<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(et => et.Id == id);
        }

        public void Update(Employee data)
        {
            if (data == null)
                throw new Exception("Employee is null");

            Employee employee = GetById(data.Id);

            employee.FirstName = data.FirstName;
            employee.Surname = data.Surname;
            employee.EmployeeType = data.EmployeeType;
            employee.Department = data.Department;
            employee.Patronymic = data.Patronymic;
            employee.Salary = data.Salary;
            
            _context.SaveChanges();
        }
    }
}
