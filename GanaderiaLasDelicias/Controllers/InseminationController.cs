using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace GanaderiaLasDelicias.Controllers
{
    [Authorize]
    public class InseminationController : Controller
    {
        private readonly SGGContext _context;

        public InseminationController(SGGContext context)
        {
            _context = context;
        }

        // GET: Insemination
        public async Task<IActionResult> Index()
        {
            var inseminations = await _context.Inseminations
                                              .Include(i => i.Cow)
                                              .Include(i => i.Bull)
                                              .ToListAsync();
            return View(inseminations);
        }

        // GET: Insemination/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insemination = await _context.Inseminations
                .Include(i => i.Cow)
                .Include(i => i.Bull)
                .FirstOrDefaultAsync(m => m.InseminationId == id);
            if (insemination == null)
            {
                return NotFound();
            }

            return View(insemination);
        }

        // GET: Insemination/Create
        public IActionResult Create()
        {
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name");
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "Name");
            ViewData["StatusOptions"] = new SelectList(new[] { "Exitosa", "Fallida" });
            return View();
        }

        // POST: Insemination/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InseminationId,CowId,BullId,Date,Status")] Insemination insemination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insemination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", insemination.CowId);
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "Name", insemination.BullId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Exitosa", "Fallida" }, insemination.Status);
            return View(insemination);
        }

        // GET: Insemination/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insemination = await _context.Inseminations.FindAsync(id);
            if (insemination == null)
            {
                return NotFound();
            }
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", insemination.CowId);
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "Name", insemination.BullId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Exitosa", "Fallida" }, insemination.Status);
            return View(insemination);
        }

        // POST: Insemination/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InseminationId,CowId,BullId,Date,Status")] Insemination insemination)
        {
            if (id != insemination.InseminationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insemination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InseminationExists(insemination.InseminationId))
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
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", insemination.CowId);
            ViewData["BullId"] = new SelectList(_context.Bulls, "BullId", "Name", insemination.BullId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Exitosa", "Fallida" }, insemination.Status);
            return View(insemination);
        }

        // GET: Insemination/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insemination = await _context.Inseminations
                .Include(i => i.Cow)
                .Include(i => i.Bull)
                .FirstOrDefaultAsync(m => m.InseminationId == id);
            if (insemination == null)
            {
                return NotFound();
            }

            return View(insemination);
        }

        // POST: Insemination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insemination = await _context.Inseminations.FindAsync(id);
            _context.Inseminations.Remove(insemination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InseminationExists(int id)
        {
            return _context.Inseminations.Any(e => e.InseminationId == id);
        }
    }
}
