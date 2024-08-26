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
    public class MilkingsController : Controller
    {
        private readonly SGGContext _context;

        public MilkingsController(SGGContext context)
        {
            _context = context;
        }

        // GET: Milkings
        public async Task<IActionResult> Index()
        {
            var sGGContext = _context.Milkings.Include(m => m.Cow).Include(m => m.Milker).Where(e => e.Milker.Status == "Activo");
            return View(await sGGContext.ToListAsync());
        }

        // GET: Milkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Milkings == null)
            {
                return NotFound();
            }

            var milking = await _context.Milkings
                .Include(m => m.Cow)
                .Include(m => m.Milker).Where(e => e.Milker.Status == "Activo")
                .FirstOrDefaultAsync(m => m.MilkingId == id);
            if (milking == null)
            {
                return NotFound();
            }

            return View(milking);
        }

        // GET: Milkings/Create
        public IActionResult Create()
        {
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name");
            // Obtener lista de empleados activos
            var activeEmployees = _context.Employees
                .Where(e => e.Status == "Activo")
                .ToList();
            ViewData["MilkerId"] = new SelectList(activeEmployees, "EmployeeId", "Name");
            return View();
        }

        // POST: Milkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MilkingId,CowId,MilkingDate,MilkingTime,MilkVolume,FatContent,ProteinContent,LactoseContent,SomaticCellCount,MilkerId")] Milking milking)
        {
            if (ModelState.IsValid)
            {
                milking.MilkingTime = new TimeSpan(12, 0, 0);

                _context.Add(milking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", milking.CowId);
            ViewData["MilkerId"] = new SelectList(_context.Employees, "EmployeeId", "Name", milking.MilkerId);
            return View(milking);
        }

        // GET: Milkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Milkings == null)
            {
                return NotFound();
            }

            var milking = await _context.Milkings.FindAsync(id);
            if (milking == null)
            {
                return NotFound();
            }
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", milking.CowId);
            ViewData["MilkerId"] = new SelectList(_context.Employees, "EmployeeId", "Name", milking.MilkerId);
            return View(milking);
        }

        // POST: Milkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MilkingId,CowId,MilkingDate,MilkingTime,MilkVolume,FatContent,ProteinContent,LactoseContent,SomaticCellCount,MilkerId")] Milking milking)
        {
            if (id != milking.MilkingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilkingExists(milking.MilkingId))
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
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", milking.CowId);
            ViewData["MilkerId"] = new SelectList(_context.Employees, "EmployeeId", "Name", milking.MilkerId);
            return View(milking);
        }

        // GET: Milkings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Milkings == null)
            {
                return NotFound();
            }

            var milking = await _context.Milkings
                .Include(m => m.Cow)
                .Include(m => m.Milker).Where(e => e.Milker.Status == "Activo")
                .FirstOrDefaultAsync(m => m.MilkingId == id);
            if (milking == null)
            {
                return NotFound();
            }

            return View(milking);
        }

        // POST: Milkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Milkings == null)
            {
                return Problem("Entity set 'SGGContext.Milkings'  is null.");
            }
            var milking = await _context.Milkings.FindAsync(id);
            if (milking != null)
            {
                _context.Milkings.Remove(milking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilkingExists(int id)
        {
          return (_context.Milkings?.Any(e => e.MilkingId == id)).GetValueOrDefault();
        }
    }
}
