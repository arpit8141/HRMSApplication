using HRMS.Core.Entities;

namespace HRMS.Core.Interfaces
{
    public interface ILeaveService
    {
        Task<bool> ApplyLeaveAsync(LeaveRequest request);
        Task ApproveLeaveAsync(int leaveId);
        Task RejectLeaveAsync(int leaveId);
    }
}
