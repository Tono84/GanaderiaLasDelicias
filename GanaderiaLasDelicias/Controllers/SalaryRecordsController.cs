using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GanaderiaLasDelicias.Models;
using static GanaderiaLasDelicias.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace GanaderiaLasDelicias.Controllers
{
    [Authorize]

    public class SalaryRecordsController : Controller
    {
        private readonly SGGContext _context;

        public SalaryRecordsController(SGGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? selectedEmployeeId)
        {
            // Obtener lista de empleados para el dropdown
            var employees = await _context.Employees.ToListAsync();
            var employeeSelectList = new SelectList(employees, "EmployeeId", "Name");

            List<SalaryRecord> salaryRecords = new List<SalaryRecord>();
            List<EmployeePaymentCount> employeePaymentsCount = new List<EmployeePaymentCount>();

            // Solo buscar si hay un empleado seleccionado
            if (selectedEmployeeId.HasValue && selectedEmployeeId > 0)
            {
                var query = _context.SalaryRecords.Include(s => s.Employee).Where(s => s.EmployeeId == selectedEmployeeId.Value);

                salaryRecords = await query.ToListAsync();

                employeePaymentsCount = salaryRecords
                    .GroupBy(s => s.Employee.Name)
                    .Select(group => new EmployeePaymentCount
                    {
                        EmployeeName = group.Key,
                        PaymentsCount = group.Count()
                    }).ToList();
            }

            var viewModel = new SalaryRecordViewModel
            {
                SalaryRecords = salaryRecords,
                EmployeePaymentsCount = employeePaymentsCount,
                Employees = employeeSelectList
            };

            return View(viewModel);
        }


        // GET: SalaryRecords/Create
        public IActionResult Create()
        {
            var activeEmployees = _context.Employees.Where(e => e.Status == "Activo").ToList();
            ViewData["EmployeeId"] = new SelectList(activeEmployees, "EmployeeId", "Name");
            return View();
        }

        // POST: SalaryRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryRecordId,EmployeeId,PaymentDate,Amount,PaymentType")] SalaryRecord salaryRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Si el empleado no está activo, mostrar un error
            ModelState.AddModelError("", "El empleado seleccionado no está activo.");

            // Recargar la lista de empleados activos
            var activeEmployees = _context.Employees.Where(e => e.Status == "Activo").ToList();
            ViewData["EmployeeId"] = new SelectList(activeEmployees, "EmployeeId", "Name", salaryRecord.EmployeeId);

            return View(salaryRecord);
        }

        public async Task<IActionResult> Details(int employeeId, int? year)
        {
            var query = _context.SalaryRecords
                .Include(s => s.Employee)
                .Where(s => s.EmployeeId == employeeId);

            if (year.HasValue)
            {
                query = query.Where(s => s.PaymentDate.Year == year.Value);
            }

            var salaryRecords = await query.ToListAsync();

            var employee = await _context.Employees.FindAsync(employeeId);
            var employeeName = employee != null ? employee.Name : "Empleado desconocido";

            var currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(2020, currentYear - 2020 + 1).Reverse().ToList();

            var viewModel = new SalaryRecordDetailsViewModel
            {
                EmployeeName = employeeName,
                SalaryRecords = salaryRecords,
                Years = years
            };

            return View(viewModel);
        }







        private bool SalaryRecordExists(int id)
        {
            return _context.SalaryRecords.Any(e => e.SalaryRecordId == id);
        }
    }
}
