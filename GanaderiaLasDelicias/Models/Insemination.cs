using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanaderiaLasDelicias.Models
{
    public partial class Insemination
    {
        [Key]
        public int InseminationId { get; set; }

        [Required]
        public int CowId { get; set; }

        [Required]
        public int BullId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!; // "Success", "Failed"

        [ForeignKey("CowId")]
        public virtual Herd? Cow { get; set; } = null!;

        [ForeignKey("BullId")]
        public virtual Bull? Bull { get; set; } = null!;
    }
}
