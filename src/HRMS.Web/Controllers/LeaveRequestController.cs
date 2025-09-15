using HRMS.Core.Entities;
using HRMS.Core.Enums;
using HRMS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMS.Web.Controllers
{
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IEmployeeService _employeeService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService, IEmployeeService employeeService)
        {
            _leaveRequestService = leaveRequestService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var leaves = await _leaveRequestService.GetAllAsync();
            return View(leaves);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Employees = await _employeeService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                leaveRequest.Status = LeaveStatus.Pending; // default
                await _leaveRequestService.ApplyLeaveAsync(leaveRequest);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveRequest);
        }

        public async Task<IActionResult> Approve(int id)
        {
            await _leaveRequestService.UpdateStatusAsync(id, LeaveStatus.Approved);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(int id)
        {
            await _leaveRequestService.UpdateStatusAsync(id, LeaveStatus.Rejected);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var leave = await _leaveRequestService.GetByIdAsync(id);
            if (leave == null) return NotFound();

            return View(leave);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveRequestService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
