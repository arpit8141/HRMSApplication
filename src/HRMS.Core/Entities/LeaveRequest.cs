using HRMS.Core.Enums;

namespace HRMS.Core.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
