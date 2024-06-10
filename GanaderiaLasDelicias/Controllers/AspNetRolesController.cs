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
    public class AspNetRolesController : Controller
    {
        private readonly SGGContext _context;

        public AspNetRolesController(SGGContext context)
        {
            _context = context;
        }

        // GET: AspNetRoles
        public async Task<IActionResult> Index()
        {
              return _context.AspNetRoles != null ? 
                          View(await _context.AspNetRoles.ToListAsync()) :
                          Problem("Entity set 'SGGContext.AspNetRoles'  is null.");
        }

        // GET: AspNetRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AspNetRoles == null)
            {
                return NotFound();
            }

            var aspNetRole = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetRole == null)
            {
                return NotFound();
            }

            return View(aspNetRole);
        }

        // GET: AspNetRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetRole);
        }

        // GET: AspNetRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AspNetRoles == null)
            {
                return NotFound();
            }

            var aspNetRole = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRole == null)
            {
                return NotFound();
            }
            return View(aspNetRole);
        }

        // POST: AspNetRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AspNetRole aspNetRole)
        {
            if (id != aspNetRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetRoleExists(aspNetRole.Id))
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
            return View(aspNetRole);
        }

        // GET: AspNetRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AspNetRoles == null)
            {
                return NotFound();
            }

            var aspNetRole = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetRole == null)
            {
                return NotFound();
            }

            return View(aspNetRole);
        }

        // POST: AspNetRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AspNetRoles == null)
            {
                return Problem("Entity set 'SGGContext.AspNetRoles'  is null.");
            }
            var aspNetRole = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRole != null)
            {
                _context.AspNetRoles.Remove(aspNetRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetRoleExists(string id)
        {
          return (_context.AspNetRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
