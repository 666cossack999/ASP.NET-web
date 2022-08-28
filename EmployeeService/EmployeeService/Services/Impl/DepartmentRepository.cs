﻿using EmployeeService.Data;

namespace EmployeeService.Services.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {

        #region Services

        private readonly EmployeeServiceDbContext _context;

        #endregion


        #region Constructor

        public DepartmentRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        #endregion

        public int Create(Department data)
        {
            _context.Departments.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public void Delete(int id)
        {
            Department department = GetById(id);
            if (department == null)
                throw new Exception("Department не найден");

            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public IList<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(et => et.Id == id);
        }

        public void Update(Department data)
        {
            if (data == null)
                throw new Exception("Department is null");

            Department department = GetById(data.Id);

            department.Description = data.Description;
            _context.SaveChanges();

        }
    }
}
