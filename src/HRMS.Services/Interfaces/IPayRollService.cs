using HRMS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IPayrollService
    {
        Task<IEnumerable<Payroll>> GetAllAsync();
        Task<Payroll> GetByIdAsync(int id);
        Task<Payroll> GeneratePayrollAsync(Payroll payroll);
        Task<Payroll> UpdateAsync(Payroll payroll);
        Task<bool> DeleteAsync(int id);
    }
}
