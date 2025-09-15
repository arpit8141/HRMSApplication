using HRMS.Core.Entities;
using HRMS.Core.Enums;
using HRMS.Infrastructure.Data;
using HRMS.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Service.Implementations
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly HRMSDbContext _context;

        public LeaveRequestService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync() =>
            await _context.LeaveRequests.Include(l => l.Employee).ToListAsync();

        public async Task<LeaveRequest> GetByIdAsync(int id) =>
            await _context.LeaveRequests.Include(l => l.Employee)
                                        .FirstOrDefaultAsync(l => l.Id == id);

        public async Task<LeaveRequest> ApplyLeaveAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> UpdateStatusAsync(int id, LeaveStatus status)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return null;

            leave.Status = status;
            _context.LeaveRequests.Update(leave);
            await _context.SaveChangesAsync();
            return leave;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return false;

            _context.LeaveRequests.Remove(leave);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
