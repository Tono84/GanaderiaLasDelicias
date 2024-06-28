using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Pregnancy
    {
        [Key]
        public int PregnancyId { get; set; }
        public int CowId { get; set; }

        [Display(Name ="Fecha")]
        public DateTime? PregDate { get; set; }
        public int BullId { get; set; }

        [Display(Name = "Notas")]
        public string? Note { get; set; }

        [Display(Name = "Toro")]
        public virtual Bull Bull { get; set; } = null!;

        [Display(Name = "Vaca")]
        public virtual Herd Cow { get; set; } = null!;
    }
}
