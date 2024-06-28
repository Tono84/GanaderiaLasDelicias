using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GanaderiaLasDelicias.Controllers
{
    public class FeedingsController : Controller
    {
        private readonly SGGContext _context;

        public FeedingsController(SGGContext context)
        {
            _context = context;
        }

        // GET: Feedings
        public async Task<IActionResult> Index()
        {
            var feedings = await _context.Feedings
                .Include(f => f.oHerd) 
                .ToListAsync();

            return View(feedings);
        }

        // GET: Feedings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feedings
                .Include(f => f.oHerd)
                .FirstOrDefaultAsync(m => m.FeedingId == id);

            if (feeding == null)
            {
                return NotFound();
            }

            return View(feeding);
        }


        public IActionResult Create()
        {
            ViewBag.HerdList = _context.Herds.ToList(); 

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedingId,CowId,SupplementConsumed,GrazingHours")] Feeding feeding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feeding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HerdList = _context.Herds.ToList(); 
            return View(feeding);
        }

        // GET: Feedings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feedings
                .Include(f => f.oHerd)
                .FirstOrDefaultAsync(m => m.FeedingId == id);
            if (feeding == null)
            {
                return NotFound();
            }

            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", feeding.CowId);

            return View(feeding);
        }

        // POST: Feedings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedingId,CowId,SupplementConsumed,GrazingHours")] Feeding feeding)
        {
            if (id != feeding.FeedingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedingExists(feeding.FeedingId))
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

            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", feeding.CowId);

            return View(feeding);
        }


        // GET: Feedings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeding = await _context.Feedings
                .Include(f => f.oHerd)
                .FirstOrDefaultAsync(m => m.FeedingId == id);

            if (feeding == null)
            {
                return NotFound();
            }

            return View(feeding);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeding = await _context.Feedings.FindAsync(id);
            _context.Feedings.Remove(feeding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool FeedingExists(int id)
        {
            return _context.Feedings.Any(e => e.FeedingId == id);
        }
    }
}
