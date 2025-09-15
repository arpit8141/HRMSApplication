using HRMS.Infrastructure.Data;
using HRMS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly HRMSDbContext _context;    
        
        public DashboardService(HRMSDbContext context) 
        {
            _context = context;    
        }

        public async Task<int> GetTotalEmployeesAsync() 
        {
            return _context.Employees.Count();
        }

        public async Task<int> GetTotalDepartmentsAsync() 
        { 
            return _context.Departments.Count();
        }

        public async Task<int> GetTotalRolesAsync()
        {
            return _context.Roles.Count();
        }

    }
}
