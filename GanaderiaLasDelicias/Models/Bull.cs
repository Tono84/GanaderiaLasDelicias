using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Bull
    {
        public Bull()
        {
            Pregnancies = new HashSet<Pregnancy>();
        }

        [Key]
        public int BullId { get; set; }

        [Display(Name="Toro")]
        public string Name { get; set; } = null!;

        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Display(Name = "Fecha de Compra")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Display(Name = "Precio")]
        public decimal SemenCost { get; set; }

        [Display(Name = "Vacas Inseminadas")]
        public int? InseminatedCows { get; set; }

        [Display(Name = "Vacas Preñadas")]
        public int? PregnantCows { get; set; }

        public virtual ICollection<Pregnancy> Pregnancies { get; set; }
    }
}
