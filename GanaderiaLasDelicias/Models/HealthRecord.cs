using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanaderiaLasDelicias.Models
{
    public partial class HealthRecord
    {
        public int HealthRecordId { get; set; }
        public int CowId { get; set; }
        public string HealthStatus { get; set; } = null!;
        public string? Treatment { get; set; }
        public string? PrescribedMedication { get; set; }
        public string? Dose { get; set; }
        public string? Frequency { get; set; }
        public DateTime? DiagnosisDate { get; set; }
        public DateTime? StateChangeDate { get; set; }
        public DateTime? CheckupDate { get; set; }
        public DateTime? VaccinationDate { get; set; }

        public virtual Herd? oHerd { get; set; }
    }
}
