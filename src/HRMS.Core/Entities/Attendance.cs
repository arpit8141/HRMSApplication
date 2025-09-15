using HRMS.Core.Enums;

namespace HRMS.Core.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public AttendanceStatus Status { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
