using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;
public class SeveranceController : Controller
{
    private readonly SGGContext _context;

    public SeveranceController(SGGContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        // Cargar empleados disponibles para el dropdown
        ViewBag.Employees = _context.Employees
            .Where(e => e.Status == "Activo")
            .Select(e => new { e.EmployeeId, Name = $"{e.Name}" })
            .ToList();

        return View();
    }
    [HttpPost]
    public IActionResult Index(int employeeId, int workingYears, decimal salary)
    {
        var severance = new Severance();
        if (workingYears >= 3)
        {
            // Calcular cesantía basada en los años trabajados
            var compensationDays = CalculateSeveranceDays(workingYears);
            severance.Compensation = compensationDays * salary;
        }

        // Cargar empleados disponibles para el dropdown
        ViewBag.Employees = _context.Employees.Where(e => e.Status == "Activo")
            .Select(e => new { e.EmployeeId, Name = $"{e.Name}" })
            .ToList();

        return View(severance);
    }

    private int CalculateSeveranceDays(int yearsWorked)
    {
        if (yearsWorked < 1) return 0;

        if (yearsWorked >= 1 && yearsWorked <= 13)
        {
            return yearsWorked switch
            {
                1 => 19,
                2 => 20,
                3 => 20,
                4 => 21,
                5 => 21,
                6 => 22,
                7 => 22,
                8 or 9 => 22,
                10 => 21,
                11 => 21,
                12 => 20,
                13 => 20,
                _ => 0
            };
        }
        return 22 * 8; // Tope máximo de 8 años de cesantía
    }
}
