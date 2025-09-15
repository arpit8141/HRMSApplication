using HRMS.Core.Entities;

namespace HRMS.Core.Interfaces
{
    public interface IPayrollService
    {
        Task<Payroll> GeneratePayrollAsync(Employee employee, DateTime month);
    }
}
