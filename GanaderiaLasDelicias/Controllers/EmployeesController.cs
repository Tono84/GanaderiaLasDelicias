﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;

namespace GanaderiaLasDelicias.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly SGGContext _context;

        public EmployeesController(SGGContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var sGGContext = _context.Employees.Include(s => s.schedule).Include(e => e.AspNetUser);
            return View(await sGGContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.AspNetUser).Include(s => s.schedule)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewBag.Employees = new SelectList(await _context.Schedules.ToListAsync(), "ScheduleId", "Name"); 
            return View();


        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,LastName,NatId,JobTitle,BaseSalary,ScheduleId,AspNetUserId,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", employee.AspNetUserId);
            ViewBag.Schedules = new SelectList(await _context.Schedules.ToListAsync(), "ScheduleId", "Name");
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                                        .Include(s => s.schedule)
                                        .FirstOrDefaultAsync(s => s.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.ToListAsync();
            ViewBag.Schedule = new SelectList(schedule, "ScheduleId", "Name", employee.ScheduleId);
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", employee.AspNetUserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,LastName,NatId,JobTitle,BaseSalary,ScheduleId,AspNetUserId,Status")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewBag.Schedules = new SelectList(await _context.Schedules.ToListAsync(), "ScheduleId", "Name", employee.ScheduleId);
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Email", employee.AspNetUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.AspNetUser).Include(s => s.schedule)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.Include(s => s.schedule).FirstOrDefaultAsync(s => s.EmployeeId == id); 

            if (employee == null)
            {
                return NotFound();
            }

            // Cambiar el estado de activo a inactivo
            employee.Status = "Inactivo";

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
