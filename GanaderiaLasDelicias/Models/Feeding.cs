using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class Feeding
    {
        public int FeedingId { get; set; }
        public int CowId { get; set; }
        public int SupplementConsumed { get; set; }
        public int GrazingHours { get; set; }

        public virtual Herd? Cow { get; set; } = null!;
    }
}
