using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Herd
    {
      
        public Herd()
        {
            MedHistories = new HashSet<MedHistory>();
            Milkings = new HashSet<Milking>();
            Nutritions = new HashSet<Nutrition>();
            Feedings = new HashSet<Feeding>();
            HealthRecords = new HashSet<HealthRecord>();
        }

        [Key]
        public int CowId { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Número registrado")]
        [Required(ErrorMessage = "El número de vaca es requerido.")]
        public int Number { get; set; }

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "La raza es requerida.")]
        public string Race { get; set; } = null!;

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "La edad es requerida.")]
        public int Age { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "El peso es requerido.")]
        public decimal Weight { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual ICollection<Milking> Milkings { get; set; }
        public virtual ICollection<Nutrition> Nutritions { get; set; }
        public virtual ICollection<Feeding> Feedings { get; set; }
        public virtual ICollection<HealthRecord> HealthRecords { get; set; }
    }
}
