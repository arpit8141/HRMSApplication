using HRMS.Core.Entities;

namespace HRMS.Core.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesWithDepartmentAndRoleAsync();
    }
}
