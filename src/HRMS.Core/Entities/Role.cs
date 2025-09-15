namespace HRMS.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;  // Admin, HR, Employee
        public ICollection<Employee>? Employees { get; set; }
    }
}
