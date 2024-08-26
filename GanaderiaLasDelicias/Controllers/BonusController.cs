using Microsoft.AspNetCore.Mvc;
using GanaderiaLasDelicias.Models;
using Microsoft.AspNetCore.Authorization;

namespace GanaderiaLasDelicias.Controllers
{
    [Authorize]
    public class BonusController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Bonus());
        }

        [HttpPost]
        public IActionResult Index(Bonus model)
        {
            if (ModelState.IsValid)
            {
                model.Resultado = model.Salarios.Sum() / 12;
                return View(model);
            }
            return View(model);
        }
    }
}

