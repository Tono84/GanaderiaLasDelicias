namespace GanaderiaLasDelicias.Models
{
    public class Feeding
    {
        public int FeedingId { get; set; }
        public int CowId { get; set; }
        public int SupplementConsumed { get; set; }
        public int GrazingHours { get; set; }


        public virtual Herd? oHerd { get; set; }

    }

}
