using HRMS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance> GetByIdAsync(int id);
        Task<Attendance> AddAsync(Attendance attendance);
        Task<Attendance> UpdateAsync(Attendance attendance);
        Task<bool> DeleteAsync(int id);
    }
}
