using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class Bull
    {
        public Bull()
        {
            Pregnancies = new HashSet<Pregnancy>();
        }

        public int BullId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Weight { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Age { get; set; }
        public decimal SemenCost { get; set; }
        public int? InseminatedCows { get; set; }
        public int? PregnantCows { get; set; }

        public virtual ICollection<Pregnancy> Pregnancies { get; set; }
    }
}
