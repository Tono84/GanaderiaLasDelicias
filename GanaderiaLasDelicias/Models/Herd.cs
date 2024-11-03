using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Herd
    {
        public Herd()
        {
            Feedings = new HashSet<Feeding>();
            HealthRecords = new HashSet<HealthRecord>();
            MedHistories = new HashSet<MedHistory>();
            Milkings = new HashSet<Milking>();
            Nutritions = new HashSet<Nutrition>();
            Pregnancies = new HashSet<Pregnancy>();
            ReprodPregnancies = new HashSet<ReprodPregnancy>();
            Inseminations = new HashSet<Insemination>();
        }

        [Key]
        public int CowId { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo debe contener letras.")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name="Nombre")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "El número asignado debe de ser un número entero.")]
        [Range(0, 999, ErrorMessage = "El número asignado debe estar entre 0 y 999")]
        [Required(ErrorMessage = "El número asignado es requerido")]
        [Display(Name = "Número Asignado")]
        public int Number { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "La raza solo debe contener letras.")]
        [Required(ErrorMessage = "La raza es requerida")]
        [Display(Name = "Raza")]
        public string Race { get; set; } = null!;

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "La edad debe de ser un número entero.")]
        [Range(0, 999, ErrorMessage = "La edad debe estar entre 0 y 999")]
        [Required(ErrorMessage = "La edad es requerida")]
        [Display(Name = "Edad(años)")]
        public int Age { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El peso debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 999.99, ErrorMessage = "El peso debe estar entre 0 y 999.99")]
        [Required(ErrorMessage = "El Peso es requerido")]
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = null!;

        public virtual ICollection<Feeding> Feedings { get; set; }
        public virtual ICollection<HealthRecord> HealthRecords { get; set; }
        public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual ICollection<Milking> Milkings { get; set; }
        public virtual ICollection<Nutrition> Nutritions { get; set; }
        public virtual ICollection<Pregnancy> Pregnancies { get; set; }
        public virtual ICollection<ReprodPregnancy> ReprodPregnancies { get; set; }
        public virtual ICollection<Insemination> Inseminations { get; set; }
    }
}
