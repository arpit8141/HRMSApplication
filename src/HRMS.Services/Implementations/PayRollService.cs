using HRMS.Core.Entities;
using HRMS.Infrastructure.Data;
using HRMS.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Service.Implementations
{
    public class PayrollService : IPayrollService
    {
        private readonly HRMSDbContext _context;

        public PayrollService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payroll>> GetAllAsync() =>
            await _context.Payrolls.Include(p => p.Employee).ToListAsync();

        public async Task<Payroll> GetByIdAsync(int id) =>
            await _context.Payrolls.Include(p => p.Employee)
                                   .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Payroll> GeneratePayrollAsync(Payroll payroll)
        {
            _context.Payrolls.Add(payroll);
            await _context.SaveChangesAsync();
            return payroll;
        }

        public async Task<Payroll> UpdateAsync(Payroll payroll)
        {
            _context.Payrolls.Update(payroll);
            await _context.SaveChangesAsync();
            return payroll;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null) return false;

            _context.Payrolls.Remove(payroll);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
