using GanaderiaLasDelicias.Data;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GanaderiaLasDelicias.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SGGContext _context;

        public HomeController(SGGContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var milkings = _context.Milkings.ToList();
            var salaryRecords = _context.SalaryRecords.ToList(); // Recupera todos los registros
            var healthRecords = _context.HealthRecords.ToList(); // Recupera todos los registros de salud
            var feedings = _context.Feedings.Include(f => f.Cow).ToList(); // Obtener datos de alimentación con información de vacas
            var viewModel = new DashboardViewModel
            {
                ActiveEmployeesCount = _context.Employees.Count(e => e.Status == "Activo"),
                PaymentsCount = _context.SalaryRecords.Count(),
                CowsCount = _context.Herds.Count(),
                PregnantCowsCount = _context.ReprodPregnancies.Count(),
                FatPercentage = milkings.Any() ? (double)(milkings.Average(m => m.FatContent ?? 0)) : 0.0,
                ProteinPercentage = milkings.Any() ? (double)(milkings.Average(m => m.ProteinContent ?? 0)) : 0.0,
                LactosePercentage = milkings.Any() ? (double)(milkings.Average(m => m.LactoseContent ?? 0)) : 0.0,


                // Obtener y procesar los datos del gráfico
                PaymentData = salaryRecords
        .GroupBy(sr => sr.PaymentDate.ToString("yyyy-MM"))
        .Select(g => new PaymentDataDto
        {
            Date = g.Key,
            TotalAmount = g.Sum(sr => sr.Amount),
            Count = g.Count()
        }).ToList(),
                // Obtener y procesar los datos del gráfico de estado de salud
        HealthStatusCounts = healthRecords
            .GroupBy(hr => hr.HealthStatus)
            .ToDictionary(g => g.Key, g => g.Count()),

                FeedingData = feedings
            .GroupBy(f => f.Cow.Name) // Agrupar por nombre de la vaca
            .Select(g => new FeedingDataDto
            {
                CowName = g.Key,
                GrazingHours = g.Sum(f => f.GrazingHours)
            }).ToList()


            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
