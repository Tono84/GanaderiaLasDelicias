using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GanaderiaLasDelicias.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }


        [Display(Name="Nombre")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo debe contener letras.")]
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Turno")]

        [Required(ErrorMessage = "El campo Tipo de Turno es requerido.")]
        public int ShiftType { get; set; }
        [Display(Name = "Días Laborales")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Los días laborales solo deben contener letras.")]
        [Required(ErrorMessage = "El campo Días a Trabajar es requerido.")]
        [StringLength(50)]
        public string WorkDays { get; set; }

        [Display(Name = "Días Libres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Los días de descanso solo deben contener letras.")]
        [Required(ErrorMessage = "El campo Días Libres es requerido.")]
        [StringLength(50)]
        public string OffDays { get; set; }

        [Display(Name = "Horas de Trabajo")]
        [Required(ErrorMessage = "El campo Horas de Trabajo es requerido.")]
        [StringLength(15)]
        public string WorkHours { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public bool IsActive { get; set; }
    }
}

