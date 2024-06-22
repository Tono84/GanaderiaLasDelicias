using System;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "El campo Días a trabajar es requerido.")]
        [Display(Name = "Días a Trabajar")]
        public string WorkDays { get; set; }

        [Required(ErrorMessage = "El campo Días libres es requerido.")]
        [Display(Name = "Días Libres")]
        public string OffDays { get; set; }

        [Required(ErrorMessage = "El campo Horas de Trabajo es requerido.")]
        [Display(Name = "Horas de Trabajo")]
        public string WorkHours { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}
