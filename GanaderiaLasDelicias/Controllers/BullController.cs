using GanaderiaLasDelicias.Data;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GanaderiaLasDelicias.Controllers
{
    public class BullController : Controller
    {
        private readonly SGGContext _context;

        public BullController(SGGContext context)
        {
            _context = context;
        }

        // GET: Bull
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bulls.ToListAsync());
        }

        // GET: Bull/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bull = await _context.Bulls
                .FirstOrDefaultAsync(m => m.BullId == id);
            if (bull == null)
            {
                return NotFound();
            }

            return View(bull);
        }

        // GET: Bull/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bull/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BullId,Name,Weight,PurchaseDate,Age,SemenCost,InseminatedCows,PregnantCows")] Bull bull)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bull);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bull);
        }

        // GET: Bull/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bull = await _context.Bulls.FindAsync(id);
            if (bull == null)
            {
                return NotFound();
            }
            return View(bull);
        }

        // POST: Bull/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BullId,Name,Weight,PurchaseDate,Age,SemenCost,InseminatedCows,PregnantCows")] Bull bull)
        {
            if (id != bull.BullId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bull);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BullExists(bull.BullId))
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
            return View(bull);
        }

        // GET & POST: Bull/Delete/5
        [HttpGet, HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bull = await _context.Bulls
                .FirstOrDefaultAsync(m => m.BullId == id);

            if (bull == null)
            {
                return NotFound();
            }

            if (HttpContext.Request.Method == "POST")
            {
                _context.Bulls.Remove(bull);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bull);
        }

        private bool BullExists(int id)
        {
            return _context.Bulls.Any(e => e.BullId == id);
        }
    }
}
