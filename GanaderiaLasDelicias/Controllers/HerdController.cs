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
    public class HerdController : Controller
    {
        private readonly SGGContext _context;

        public HerdController(SGGContext context)
        {
            _context = context;
        }

        // GET: Herd
        public async Task<IActionResult> Index()
        {
              return _context.Herds != null ? 
                          View(await _context.Herds.ToListAsync()) :
                          Problem("Entity set 'SGGContext.Herds'  is null.");
        }

        // GET: Herd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Herds == null)
            {
                return NotFound();
            }

            var herd = await _context.Herds
                .FirstOrDefaultAsync(m => m.CowId == id);
            if (herd == null)
            {
                return NotFound();
            }

            return View(herd);
        }

        // GET: Herd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CowId,Name,Number,Race,Age,Weight,Status")] Herd herd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(herd);
        }

        // GET: Herd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Herds == null)
            {
                return NotFound();
            }

            var herd = await _context.Herds.FindAsync(id);
            if (herd == null)
            {
                return NotFound();
            }
            return View(herd);
        }

        // POST: Herd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CowId,Name,Number,Race,Age,Weight,Status")] Herd herd)
        {
            if (id != herd.CowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerdExists(herd.CowId))
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
            return View(herd);
        }

        // GET: Herd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Herds == null)
            {
                return NotFound();
            }

            var herd = await _context.Herds
                .FirstOrDefaultAsync(m => m.CowId == id);
            if (herd == null)
            {
                return NotFound();
            }

            return View(herd);
        }

        // POST: Herd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Herds == null)
            {
                return Problem("Entity set 'SGGContext.Herds'  is null.");
            }
            var herd = await _context.Herds.FindAsync(id);
            if (herd != null)
            {
                _context.Herds.Remove(herd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerdExists(int id)
        {
          return (_context.Herds?.Any(e => e.CowId == id)).GetValueOrDefault();
        }
    }
}
