using GanaderiaLasDelicias.Data;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GanaderiaLasDelicias.Controllers
{
    //[Authorize]
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
            var salaryRecords = _context.SalaryRecords.ToList(); // Recupera todos los registros

            var viewModel = new DashboardViewModel
            {
                ActiveEmployeesCount = _context.Employees.Count(e => e.Status == "Activo"),
                PaymentsCount = _context.SalaryRecords.Count(),
                CowsCount = _context.Herds.Count(),
                PregnantCowsCount = _context.ReprodPregnancies.Count(),

                // Obtener y procesar los datos del gráfico
                PaymentData = salaryRecords
        .GroupBy(sr => sr.PaymentDate.ToString("yyyy-MM"))
        .Select(g => new PaymentDataDto
        {
            Date = g.Key,
            TotalAmount = g.Sum(sr => sr.Amount),
            Count = g.Count()
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
