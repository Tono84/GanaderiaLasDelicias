using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;

namespace GanaderiaLasDelicias.Controllers
{
    public class SalariesController : Controller
    {
        private readonly SGGContext _context;

        public SalariesController(SGGContext context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            var salaries = await _context.Salary
                                         .Include(s => s.Employee) // Include Employee data
                                         .ToListAsync();
            return View(salaries);
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salary == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                                .Include(s => s.Employee) // Include Employee data
                .FirstOrDefaultAsync(m => m.SalaryId == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public async Task<IActionResult> Create()
        {
            // Obtener todos los empleados de la base de datos
            ViewBag.Employees = new SelectList(await _context.Employees.ToListAsync(), "EmployeeId", "Name"); // FullName es el nombre completo del empleado
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryId,EmployeeId,GrossSalary,Deductions,NetSalary,VacationsUsed,CreatedDate")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(await _context.Employees.ToListAsync(), "EmployeeId", "Name");
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salary == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary
                                .Include(s => s.Employee) // Include Employee data
                                .FirstOrDefaultAsync(s => s.SalaryId == id);
            if (salary == null)
            {
                return NotFound();
            }
            // Obtener la lista de empleados
            var employees = await _context.Employees.ToListAsync();

            // Crear la lista desplegable y preseleccionar el empleado actual
            ViewBag.Employees = new SelectList(employees, "EmployeeId", "FullName", salary.EmployeeId);

            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryId,EmployeeId,GrossSalary,Deductions,NetSalary,VacationsUsed,CreatedDate")] Salary salary)
        {
            if (id != salary.SalaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.SalaryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = new SelectList(await _context.Employees.ToListAsync(), "EmployeeId", "Name", salary.EmployeeId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salary == null)
            {
                return NotFound();
            }

            var salary = await _context.Salary.Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SalaryId == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salary == null)
            {
                return Problem("Entity set 'SGGContext.Salary'  is null.");
            }
            var salary = await _context.Salary.Include(s => s.Employee) // Include Employee data
                .FirstOrDefaultAsync(s => s.SalaryId == id); ;
            if (salary != null)
            {
                _context.Salary.Remove(salary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(int id)
        {
          return (_context.Salary?.Any(e => e.SalaryId == id)).GetValueOrDefault();
        }
    }
}
