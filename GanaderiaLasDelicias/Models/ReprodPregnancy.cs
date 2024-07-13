using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanaderiaLasDelicias.Models
{
    public partial class ReprodPregnancy
    {
        [Key]
        public int ReprodPregnancyId { get; set; }

        [Required]
        public int CowId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!; // "Completed", "Aborted"

        [ForeignKey("CowId")]
        public virtual Herd? Cow { get; set; } = null!;
    }
}
