using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class HealthRecord
    {
        [Key]
        public int HealthRecordId { get; set; }
        public int CowId { get; set; }
        public string HealthStatus { get; set; } = null!;


        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El tratamiento solo debe contener letras.")]
        [Display(Name = "Tratamiento")]
        public string? Treatment { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Medicación Prescrita solo debe contener letras.")]
        [Display(Name = "Medicación Prescrita")]
        public string? PrescribedMedication { get; set; }

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "La dosis debe de ser un número entero.")]
        [Range(0, 9999, ErrorMessage = "Las dosis debe estar entre 0 y 9999")]
        [Display(Name = "Dosis")]
        public string? Dose { get; set; }

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "La dosis debe de ser un número entero.")]
        [Range(0, 999, ErrorMessage = "Las Frecuencia debe estar entre 0 y 99")]
        [Display(Name = "Frecuencia(Días)")]
        public string? Frequency { get; set; }
        public DateTime? DiagnosisDate { get; set; }
        public DateTime? StateChangeDate { get; set; }

        [Required(ErrorMessage = "La fecha de chequeo es requerida")]
        [Display(Name = "Fecha de Chequeo")]
        public DateTime? CheckupDate { get; set; }
        public DateTime? VaccinationDate { get; set; }

        public virtual Herd? Cow { get; set; } = null!;
    }
}
