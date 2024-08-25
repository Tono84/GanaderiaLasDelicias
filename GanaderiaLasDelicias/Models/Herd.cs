using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Herd
    {
        public Herd()
        {
            Feedings = new HashSet<Feeding>();
            HealthRecords = new HashSet<HealthRecord>();
            MedHistories = new HashSet<MedHistory>();
            Milkings = new HashSet<Milking>();
            Nutritions = new HashSet<Nutrition>();
            Pregnancies = new HashSet<Pregnancy>();
            ReprodPregnancies = new HashSet<ReprodPregnancy>();
            Inseminations = new HashSet<Insemination>();
        }

        [Key]
        public int CowId { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; } = null!;

        [Display(Name = "Número Asignado")]
        public int Number { get; set; }

        [Display(Name = "Raza")]
        public string Race { get; set; } = null!;

        [Display(Name = "Edad (Años)")]
        public int Age { get; set; }

        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual ICollection<Feeding> Feedings { get; set; }
        public virtual ICollection<HealthRecord> HealthRecords { get; set; }
        public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual ICollection<Milking> Milkings { get; set; }
        public virtual ICollection<Nutrition> Nutritions { get; set; }
        public virtual ICollection<Pregnancy> Pregnancies { get; set; }
        public virtual ICollection<ReprodPregnancy> ReprodPregnancies { get; set; }
        public virtual ICollection<Insemination> Inseminations { get; set; }
    }
}
