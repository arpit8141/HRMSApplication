namespace HRMS.Core.Entities
{
    public class Payroll
    {
        public int Id { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary => BasicSalary + Allowances - Deductions;

        public DateTime Month { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
