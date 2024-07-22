using System;
using System.Collections.Generic;

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

        public int CowId { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public string Race { get; set; } = null!;
        public int Age { get; set; }
        public decimal Weight { get; set; }
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
