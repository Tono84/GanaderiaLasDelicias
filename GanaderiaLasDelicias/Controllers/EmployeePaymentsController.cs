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
    public class EmployeePaymentsController : Controller
    {
        private readonly SGGContext _context;

        public EmployeePaymentsController(SGGContext context)
        {
            _context = context;
        }

        // GET: EmployeePayments
        public async Task<IActionResult> Index()
        {
            var sGGContext = _context.EmployeePayments.Include(e => e.Employee).Include(e => e.Payment);
            return View(await sGGContext.ToListAsync());
        }

        // GET: EmployeePayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeePayments == null)
            {
                return NotFound();
            }

            var employeePayment = await _context.EmployeePayments
                .Include(e => e.Employee)
                .Include(e => e.Payment)
                .FirstOrDefaultAsync(m => m.EmployeePaymentId == id);
            if (employeePayment == null)
            {
                return NotFound();
            }

            return View(employeePayment);
        }

        // GET: EmployeePayments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PayId", "PayId");
            return View();
        }

        // POST: EmployeePayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeePaymentId,VacationsUsed,NetPay,EmployeeId,PaymentId")] EmployeePayment employeePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeePayment.EmployeeId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PayId", "PayId", employeePayment.PaymentId);
            return View(employeePayment);
        }

        // GET: EmployeePayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeePayments == null)
            {
                return NotFound();
            }

            var employeePayment = await _context.EmployeePayments.FindAsync(id);
            if (employeePayment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeePayment.EmployeeId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PayId", "PayId", employeePayment.PaymentId);
            return View(employeePayment);
        }

        // POST: EmployeePayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeePaymentId,VacationsUsed,NetPay,EmployeeId,PaymentId")] EmployeePayment employeePayment)
        {
            if (id != employeePayment.EmployeePaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePaymentExists(employeePayment.EmployeePaymentId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeePayment.EmployeeId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PayId", "PayId", employeePayment.PaymentId);
            return View(employeePayment);
        }

        // GET: EmployeePayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeePayments == null)
            {
                return NotFound();
            }

            var employeePayment = await _context.EmployeePayments
                .Include(e => e.Employee)
                .Include(e => e.Payment)
                .FirstOrDefaultAsync(m => m.EmployeePaymentId == id);
            if (employeePayment == null)
            {
                return NotFound();
            }

            return View(employeePayment);
        }

        // POST: EmployeePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeePayments == null)
            {
                return Problem("Entity set 'SGGContext.EmployeePayments'  is null.");
            }
            var employeePayment = await _context.EmployeePayments.FindAsync(id);
            if (employeePayment != null)
            {
                _context.EmployeePayments.Remove(employeePayment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePaymentExists(int id)
        {
          return (_context.EmployeePayments?.Any(e => e.EmployeePaymentId == id)).GetValueOrDefault();
        }
    }
}
