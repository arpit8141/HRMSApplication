using HRMS.Core.Entities;
using HRMS.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest> GetByIdAsync(int id);
        Task<LeaveRequest> ApplyLeaveAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest> UpdateStatusAsync(int id, LeaveStatus status);
        Task<bool> DeleteAsync(int id);
    }
}
