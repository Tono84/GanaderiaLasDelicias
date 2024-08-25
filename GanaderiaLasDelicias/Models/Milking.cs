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
        public decimal MilkVolume { get; set; }
        public decimal? FatContent { get; set; }
        public decimal? ProteinContent { get; set; }
        public decimal? LactoseContent { get; set; }
        public int? SomaticCellCount { get; set; }
        public int? MilkerId { get; set; }

        public virtual Herd? Cow { get; set; } = null!;
        public virtual Employee? Milker { get; set; }
    }
}
