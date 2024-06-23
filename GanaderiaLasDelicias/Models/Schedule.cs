using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Turno es requerido.")]
        public int ShiftType { get; set; } // 1 para diurno, 2 para nocturno

        [Required(ErrorMessage = "El campo Días a Trabajar es requerido.")]
        [StringLength(50)]
        public string WorkDays { get; set; }

        [Required(ErrorMessage = "El campo Días Libres es requerido.")]
        [StringLength(50)]
        public string OffDays { get; set; }

        [Required(ErrorMessage = "El campo Horas de Trabajo es requerido.")]
        [StringLength(50)]
        public string WorkHours { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}

