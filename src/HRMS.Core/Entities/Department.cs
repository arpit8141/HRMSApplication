namespace HRMS.Core.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // One-to-Many
        public ICollection<Employee>? Employees { get; set; }
    }
}
