using HRMS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Data
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee -> Department relation
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            // Employee -> Role relation
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);

            // 🔹 Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Human Resources" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "Finance" }
            );

            // 🔹 Seed Roles (using RoleName now)
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "HR" },
                new Role { Id = 3, RoleName = "Employee" }
            );

            // 🔹 Seed Employee (Admin User)
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "admin@hrms.com",
                    DepartmentId = 2, // IT
                    RoleId = 1,       // Admin
                    DateOfJoining = new DateTime(2025, 01, 01)
                }
            );
        }
    }
}
