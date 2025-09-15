using HRMS.Core.Entities;
using HRMS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMS.Web.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IEmployeeService _employeeService;

        public AttendanceController(IAttendanceService attendanceService, IEmployeeService employeeService)
        {
            _attendanceService = attendanceService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var attendances = await _attendanceService.GetAllAsync();
            return View(attendances);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Employees = await _employeeService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                await _attendanceService.AddAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var attendance = await _attendanceService.GetByIdAsync(id);
            if (attendance == null) return NotFound();

            ViewBag.Employees = await _employeeService.GetAllAsync();
            return View(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                await _attendanceService.UpdateAsync(attendance);
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _attendanceService.GetByIdAsync(id);
            if (attendance == null) return NotFound();

            return View(attendance);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
