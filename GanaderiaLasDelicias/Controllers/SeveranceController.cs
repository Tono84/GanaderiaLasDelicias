using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Mvc;

namespace GanaderiaLasDelicias.Controllers
{
    public class SeveranceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Severance());
        }

        [HttpPost]
        public IActionResult Calculate(Severance model)
        {
            if (ModelState.IsValid)
            {
                model.Cesantia = CalculateCesantia(model.YearsWorked, model.FinalSalary, model.GaveNotice);
                return View("Index", model);
            }
            return View("Index", model);
        }

        private decimal CalculateCesantia(int yearsWorked, decimal finalSalary, bool gaveNotice)
        {
            decimal cesantia = 0;
            if (yearsWorked <= 5)
            {
                cesantia = finalSalary * yearsWorked * 0.5m;
            }
            else if (yearsWorked <= 10)
            {
                cesantia = finalSalary * yearsWorked * 0.75m;
            }
            else
            {
                cesantia = finalSalary * yearsWorked;
            }

            if (!gaveNotice)
            {
                cesantia += finalSalary;
            }

            return cesantia;
        }
    }
}
