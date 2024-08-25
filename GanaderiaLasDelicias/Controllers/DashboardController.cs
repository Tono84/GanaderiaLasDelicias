using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GanaderiaLasDelicias.Models;

namespace GanaderiaLasDelicias.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SGGContext _context;


        public DashboardController(SGGContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Obtener el conteo de empleados activos
            int activeEmployeesCount = _context.Employees.Count(e => e.Status == "Activo");

            // Obtener el conteo de pagos realizados
            int paymentsCount = _context.SalaryRecords.Count();

            // Obtener el conteo de vacas
            int cowsCount = _context.Herds.Count();

            // Obtener el conteo de vacas preñadas
            int pregnantCowsCount = _context.ReprodPregnancies.Count();

            // Inicializar el ViewModel con los datos
            var viewModel = new DashboardViewModel
            {
                ActiveEmployeesCount = activeEmployeesCount,
                PaymentsCount = paymentsCount,
                CowsCount = cowsCount,
                PregnantCowsCount = pregnantCowsCount
            };

            // Pasar el ViewModel a la vista
            return View(viewModel);
        }
    }
}
