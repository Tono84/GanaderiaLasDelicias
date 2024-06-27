using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GanaderiaLasDelicias.Controllers
{
    public class HealthRecordsController : Controller
    {
        private readonly SGGContext _context;

        public HealthRecordsController(SGGContext context)
        {
            _context = context;
        }

        // GET: HealthRecords
        public async Task<IActionResult> Index()
        {
            var healthRecords = await _context.HealthRecords
                .Include(h => h.oHerd)
                .ToListAsync();
            return View(healthRecords);
        }

        // GET: HealthRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecords
                .Include(h => h.oHerd)
                .FirstOrDefaultAsync(m => m.HealthRecordId == id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            return View(healthRecord);
        }

        // GET: HealthRecords/Create
        public IActionResult Create()
        {
            ViewBag.HerdList = _context.Herds.ToList(); 
            return View();
        }

        // POST: HealthRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HealthRecordId,CowId,HealthStatus,Treatment,PrescribedMedication,Dose,Frequency,DiagnosisDate,StateChangeDate,CheckupDate,VaccinationDate")] HealthRecord healthRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.HerdList = _context.Herds.ToList(); 
            return View(healthRecord);
        }

        // GET: HealthRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecords.FindAsync(id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            ViewBag.HerdList = _context.Herds.ToList(); 
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", healthRecord.CowId);
            return View(healthRecord);
        }

        // POST: HealthRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HealthRecordId,CowId,HealthStatus,Treatment,PrescribedMedication,Dose,Frequency,DiagnosisDate,StateChangeDate,CheckupDate,VaccinationDate")] HealthRecord healthRecord)
        {
            if (id != healthRecord.HealthRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthRecordExists(healthRecord.HealthRecordId))
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

            ViewBag.HerdList = _context.Herds.ToList(); 
            ViewData["CowId"] = new SelectList(_context.Herds, "CowId", "Name", healthRecord.CowId);
            return View(healthRecord);
        }


        // GET: HealthRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthRecord = await _context.HealthRecords
                .Include(h => h.oHerd)
                .FirstOrDefaultAsync(m => m.HealthRecordId == id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            return View(healthRecord);
        }

        // POST: HealthRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthRecord = await _context.HealthRecords.FindAsync(id);
            _context.HealthRecords.Remove(healthRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthRecordExists(int id)
        {
            return _context.HealthRecords.Any(e => e.HealthRecordId == id);
        }
    }
}
