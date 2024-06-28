using System;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public class Bull
    {
        public int BullId { get; set; }

        [Required(ErrorMessage = "El nombre del toro es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre debe tener como máximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El peso del toro es requerido.")]
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "La fecha de compra es requerida.")]
        [Display(Name = "Fecha de Compra")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "La edad del toro es requerida.")]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Required(ErrorMessage = "El costo del semen es requerido.")]
        [Display(Name = "Costo de Semen")]
        public decimal SemenCost { get; set; }

        [Display(Name = "Número de Vacas Inseminadas")]
        public int? InseminatedCows { get; set; }

        [Display(Name = "Número de Vacas Preñadas")]
        public int? PregnantCows { get; set; }
    }
}
