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
    public class PregnanciesController : Controller
    {
        private readonly SGGContext _context;

        public PregnanciesController(SGGContext context)
        {
            _context = context;
        }

        // GET: Pregnancies
        public async Task<IActionResult> Index()
        {
            var sGGContext = _context.Pregnancies.Include(p => p.Bull).Include(p => p.Cow);
            return View(await sGGContext.ToListAsync());
        }

        // GET: Pregnancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pregnancies == null)
            {
                return NotFound();
            }

            var pregnancy = await _context.Pregnancies
                .Include(p => p.Bull)
                .Include(p => p.Cow)
                .FirstOrDefaultAsync(m => m.PregnancyId == id);
            if (pregnancy == null)
            {
                return NotFound();
            }

            return View(pregnancy);
        }

        // GET: Pregnancies/Create
        public IActionResult Create()
        {
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "BullId");
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "CowId");
            return View();
        }

        // POST: Pregnancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PregnancyId,CowId,PregDate,BullId,Note")] Pregnancy pregnancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pregnancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "BullId", pregnancy.BullId);
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "CowId", pregnancy.CowId);
            return View(pregnancy);
        }

        // GET: Pregnancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pregnancies == null)
            {
                return NotFound();
            }

            var pregnancy = await _context.Pregnancies.FindAsync(id);
            if (pregnancy == null)
            {
                return NotFound();
            }
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "BullId", pregnancy.BullId);
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "CowId", pregnancy.CowId);
            return View(pregnancy);
        }

        // POST: Pregnancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PregnancyId,CowId,PregDate,BullId,Note")] Pregnancy pregnancy)
        {
            if (id != pregnancy.PregnancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregnancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PregnancyExists(pregnancy.PregnancyId))
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
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "BullId", pregnancy.BullId);
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "CowId", pregnancy.CowId);
            return View(pregnancy);
        }

        // GET: Pregnancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pregnancies == null)
            {
                return NotFound();
            }

            var pregnancy = await _context.Pregnancies
                .Include(p => p.Bull)
                .Include(p => p.Cow)
                .FirstOrDefaultAsync(m => m.PregnancyId == id);
            if (pregnancy == null)
            {
                return NotFound();
            }

            return View(pregnancy);
        }

        // POST: Pregnancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pregnancies == null)
            {
                return Problem("Entity set 'SGGContext.Pregnancies'  is null.");
            }
            var pregnancy = await _context.Pregnancies.FindAsync(id);
            if (pregnancy != null)
            {
                _context.Pregnancies.Remove(pregnancy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PregnancyExists(int id)
        {
          return (_context.Pregnancies?.Any(e => e.PregnancyId == id)).GetValueOrDefault();
        }
    }
}
