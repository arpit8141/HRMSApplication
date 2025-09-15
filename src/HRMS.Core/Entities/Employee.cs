using System.Data;

namespace HRMS.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfJoining { get; set; }
        public decimal Salary { get; set; }

        // Relationships
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}
