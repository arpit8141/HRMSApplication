using HRMS.Core.Entities;
using HRMS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMS.Web.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IPayrollService _payrollService;
        private readonly IEmployeeService _employeeService;

        public PayrollController(IPayrollService payrollService, IEmployeeService employeeService)
        {
            _payrollService = payrollService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var payrolls = await _payrollService.GetAllAsync();
            return View(payrolls);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Employees = await _employeeService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                await _payrollService.GeneratePayrollAsync(payroll);
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var payroll = await _payrollService.GetByIdAsync(id);
            if (payroll == null) return NotFound();

            ViewBag.Employees = await _employeeService.GetAllAsync();
            return View(payroll);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                await _payrollService.UpdateAsync(payroll);
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var payroll = await _payrollService.GetByIdAsync(id);
            if (payroll == null) return NotFound();

            return View(payroll);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _payrollService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
