using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class Treatment
    {
        public Treatment()
        {
            MedHistories = new HashSet<MedHistory>();
        }

        public int TreatmentId { get; set; }
        public string MedName { get; set; } = null!;
        public string Frequency { get; set; } = null!;
        public string Dosis { get; set; } = null!;

        public virtual ICollection<MedHistory> MedHistories { get; set; }
    }
}
