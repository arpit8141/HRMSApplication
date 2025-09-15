using HRMS.Core.Entities;
using HRMS.Infrastructure.Data;
using HRMS.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly HRMSDbContext _context;

        public RoleService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles
                .Include(r => r.Employees)
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .Include(r => r.Employees)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role> AddAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
