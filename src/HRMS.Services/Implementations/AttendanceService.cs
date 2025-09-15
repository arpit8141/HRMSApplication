using HRMS.Core.Entities;
using HRMS.Infrastructure.Data;
using HRMS.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Service.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly HRMSDbContext _context;

        public AttendanceService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync() =>
            await _context.Attendances.Include(a => a.Employee).ToListAsync();

        public async Task<Attendance> GetByIdAsync(int id) =>
            await _context.Attendances.Include(a => a.Employee)
                                      .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await _context.Attendances.FindAsync(id);
            if (record == null) return false;

            _context.Attendances.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
