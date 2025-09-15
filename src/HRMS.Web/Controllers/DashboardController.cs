using HRMS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMS.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new
            {
                TotalEmployees = await _dashboardService.GetTotalEmployeesAsync(),
                TotalDepartments = await _dashboardService.GetTotalDepartmentsAsync(),
                TotalRoles = await _dashboardService.GetTotalRolesAsync(),
                //TodayAttendance = await _dashboardService.GetTodayAttendanceCountAsync(),
                //PendingLeaves = await _dashboardService.GetPendingLeaveRequestsAsync(),
                //ThisMonthPayroll = await _dashboardService.GetThisMonthPayrollAsync()
            };

            return View(model);
        }
    }
}
