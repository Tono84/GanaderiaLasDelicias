using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Authorization;

namespace GanaderiaLasDelicias.Controllers
{
    [Authorize]
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
            // Validación de salario bruto (GrossSalary)
            if (salary.GrossSalary == null)
            {
                ModelState.AddModelError("GrossSalary", "El salario bruto es requerido.");
            }
            else if (salary.GrossSalary <= 0)
            {
                ModelState.AddModelError("GrossSalary", "El salario bruto debe ser un número positivo.");
            }
            else if (salary.GrossSalary > 9999999.99m)
            {
                ModelState.AddModelError("GrossSalary", "El salario bruto no puede ser mayor que 9,999,999.99.");
            }

            // Validación de deducciones (Deductions)
            if (salary.Deductions == null)
            {
                ModelState.AddModelError("Deductions", "Las deducciones son requeridas.");
            }
            else if (salary.Deductions < 0)
            {
                ModelState.AddModelError("Deductions", "Las deducciones no pueden ser un número negativo.");
            }
            else if (salary.Deductions > 9999999.99m)
            {
                ModelState.AddModelError("Deductions", "Las deducciones no pueden ser mayores que 9,999,999.99.");
            }

            // Validación de salario neto (NetSalary)
            if (salary.NetSalary == null)
            {
                ModelState.AddModelError("NetSalary", "El salario neto es requerido.");
            }
            else if (salary.NetSalary <= 0)
            {
                ModelState.AddModelError("NetSalary", "El salario neto debe ser un número positivo.");
            }
            else if (salary.NetSalary > 9999999.99m)
            {
                ModelState.AddModelError("NetSalary", "El salario neto no puede ser mayor que 9,999,999.99.");
            }

            // Validación de vacaciones usadas (VacationsUsed)
            if (salary.VacationsUsed == null)
            {
                ModelState.AddModelError("VacationsUsed", "El número de vacaciones usadas es requerido.");
            }
            else if (salary.VacationsUsed < 0)
            {
                ModelState.AddModelError("VacationsUsed", "Las vacaciones usadas no pueden ser negativas.");
            }
            else if (salary.VacationsUsed > 999)
            {
                ModelState.AddModelError("VacationsUsed", "Las vacaciones usadas no pueden ser mayores que 999 días.");
            }
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
            ViewBag.Employees = new SelectList(employees, "EmployeeId", "Name", salary.EmployeeId);

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
