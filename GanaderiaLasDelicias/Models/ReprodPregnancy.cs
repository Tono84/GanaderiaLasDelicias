using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanaderiaLasDelicias.Models
{
    public partial class ReprodPregnancy
    {
        [Key]
        public int ReprodPregnancyId { get; set; }

        [Display(Name="Vaca")]
        [Required]
        public int CowId { get; set; }

        [Display(Name = "Fecha de Embarazo")]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "Termino de Embarazo")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Notas")]
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!; // "Completed", "Aborted"

        [ForeignKey("CowId")]
        public virtual Herd? Cow { get; set; } = null!;
    }
}
