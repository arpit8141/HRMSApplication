using HRMS.Core.Entities;
using HRMS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IRoleService _roleService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IRoleService roleService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _roleService = roleService;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();
            return View(employees);
        }

        // GET: Employee/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Roles = await _roleService.GetAllAsync();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null) return NotFound();

            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Roles = await _roleService.GetAllAsync();

            return View(employee);
        }

        // POST: Employee/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        // POST: Employee/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
