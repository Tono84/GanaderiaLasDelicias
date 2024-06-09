using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class MedHistory
    {
        public int MedHistoryId { get; set; }
        public int CowId { get; set; }
        public int TreatmentId { get; set; }

        public virtual Herd Cow { get; set; } = null!;
        public virtual Treatment Treatment { get; set; } = null!;
    }
}
