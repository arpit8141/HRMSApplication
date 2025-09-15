namespace HRMS.Service.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetTotalEmployeesAsync();
        Task<int> GetTotalDepartmentsAsync();
        Task<int> GetTotalRolesAsync();
        //Task<int> GetTodayAttendanceCountAsync();
        //Task<int> GetPendingLeaveRequestsAsync();
        //Task<decimal> GetThisMonthPayrollAsync();
    }
}
