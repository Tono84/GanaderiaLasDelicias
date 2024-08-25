using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GanaderiaLasDelicias.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }


        [Display(Name="Nombre")]
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Turno")]
        [Required(ErrorMessage = "El campo Tipo de Turno es requerido.")]
        public int ShiftType { get; set; } // 1 para diurno, 2 para nocturno
        [Display(Name = "Días Laborales")]
        [Required(ErrorMessage = "El campo Días a Trabajar es requerido.")]
        [StringLength(50)]
        public string WorkDays { get; set; }

        [Display(Name = "Días Libres")]
        [Required(ErrorMessage = "El campo Días Libres es requerido.")]
        [StringLength(50)]
        public string OffDays { get; set; }

        [Display(Name = "Horas de Trabajo")]
        [Required(ErrorMessage = "El campo Horas de Trabajo es requerido.")]
        [StringLength(50)]
        public string WorkHours { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public bool IsActive { get; set; }
    }
}

