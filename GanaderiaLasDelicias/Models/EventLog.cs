using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class EventLog
    {
        public int EventId { get; set; }
        public string EventDescription { get; set; } = null!;
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
    }
}
