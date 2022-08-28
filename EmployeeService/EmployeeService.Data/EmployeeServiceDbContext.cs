using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public class EmployeeServiceDbContext : DbContext
    {
        public EmployeeServiceDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
