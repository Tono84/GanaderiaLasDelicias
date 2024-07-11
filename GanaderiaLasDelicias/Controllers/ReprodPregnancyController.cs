using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GanaderiaLasDelicias.Controllers
{
    public class ReprodPregnancyController : Controller
    {
        private readonly SGGContext _context;

        public ReprodPregnancyController(SGGContext context)
        {
            _context = context;
        }

        // GET: ReprodPregnancy
        public async Task<IActionResult> Index()
        {
            var pregnancies = await _context.ReprodPregnancies.Include(r => r.Cow).ToListAsync();
            return View(pregnancies);
        }

        // GET: ReprodPregnancy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reprodPregnancy = await _context.ReprodPregnancies
                .Include(r => r.Cow)
                .FirstOrDefaultAsync(m => m.ReprodPregnancyId == id);
            if (reprodPregnancy == null)
            {
                return NotFound();
            }

            return View(reprodPregnancy);
        }

        // GET: ReprodPregnancy/Create
        public IActionResult Create()
        {
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name");
            ViewData["StatusOptions"] = new SelectList(new[] { "Completed", "Aborted" });
            return View();
        }

        // POST: ReprodPregnancy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReprodPregnancyId,CowId,StartDate,EndDate,Status")] ReprodPregnancy reprodPregnancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reprodPregnancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", reprodPregnancy.CowId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Completed", "Aborted" }, reprodPregnancy.Status);
            return View(reprodPregnancy);
        }

        // GET: ReprodPregnancy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reprodPregnancy = await _context.ReprodPregnancies.FindAsync(id);
            if (reprodPregnancy == null)
            {
                return NotFound();
            }
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", reprodPregnancy.CowId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Completed", "Aborted" }, reprodPregnancy.Status);
            return View(reprodPregnancy);
        }

        // POST: ReprodPregnancy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReprodPregnancyId,CowId,StartDate,EndDate,Status")] ReprodPregnancy reprodPregnancy)
        {
            if (id != reprodPregnancy.ReprodPregnancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reprodPregnancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReprodPregnancyExists(reprodPregnancy.ReprodPregnancyId))
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
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", reprodPregnancy.CowId);
            ViewData["StatusOptions"] = new SelectList(new[] { "Completed", "Aborted" }, reprodPregnancy.Status);
            return View(reprodPregnancy);
        }

        // GET: ReprodPregnancy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reprodPregnancy = await _context.ReprodPregnancies
                .Include(r => r.Cow)
                .FirstOrDefaultAsync(m => m.ReprodPregnancyId == id);
            if (reprodPregnancy == null)
            {
                return NotFound();
            }

            return View(reprodPregnancy);
        }

        // POST: ReprodPregnancy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reprodPregnancy = await _context.ReprodPregnancies.FindAsync(id);
            _context.ReprodPregnancies.Remove(reprodPregnancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReprodPregnancyExists(int id)
        {
            return _context.ReprodPregnancies.Any(e => e.ReprodPregnancyId == id);
        }
    }
}
