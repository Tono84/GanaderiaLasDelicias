using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class Milking
    {
        public int MilkingId { get; set; }
        public int CowId { get; set; }
        public DateTime MilkingDate { get; set; }
        public TimeSpan MilkingTime { get; set; }
        public double MilkVolume { get; set; }
        public double? FatContent { get; set; }
        public double? ProteinContent { get; set; }
        public double? LactoseContent { get; set; }
        public int? SomaticCellCount { get; set; }
        public int? MilkerId { get; set; }

        public virtual Herd Cow { get; set; } = null!;
        public virtual Employee? Milker { get; set; }
    }
}
