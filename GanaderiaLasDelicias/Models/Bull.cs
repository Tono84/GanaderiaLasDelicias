using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Bull
    {
        public Bull()
        {
            Pregnancies = new HashSet<Pregnancy>();
            Inseminations = new HashSet<Insemination>();
           
    }

        [Key]
        public int BullId { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre del toro solo debe contener letras.")]
        [Required(ErrorMessage = "El toro es requerido")]
        [Display(Name="Toro")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El peso debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 999.99, ErrorMessage = "El peso debe estar entre 0 y 999.99")]
        [Required(ErrorMessage = "El Peso es requerido")]
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "La fecha de compra es requerida")]
        [Display(Name = "Fecha de Compra")]
        public DateTime PurchaseDate { get; set; }

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "La edad debe de ser un número entero.")]
        [Range(0, 999, ErrorMessage = "La edad debe estar entre 0 y 999")]
        [Required(ErrorMessage = "La edad es requerida")]
        [Display(Name = "Edad(años)")]
        public int Age { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 9999.99, ErrorMessage = "El precio debe estar entre 0 y 9999.99")]
        [Required(ErrorMessage = "El precio es requerido")]
        [Display(Name = "Precio")]
        public decimal SemenCost { get; set; }

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "Vacas Inseminadas deben de ser un número entero.")]
        [Range(0, 999, ErrorMessage = "Vacas Inseminadas deben estar entre 0 y 999")]
        [Display(Name = "Vacas Inseminadas")]
        public int? InseminatedCows { get; set; }

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "Vacas Inseminadas deben de ser un número entero.")]
        [Range(0, 999, ErrorMessage = "Vacas Inseminadas deben estar entre 0 y 999")]
        [Display(Name = "Vacas Preñadas")]
        public int? PregnantCows { get; set; }

        public virtual ICollection<Pregnancy> Pregnancies { get; set; }
        public virtual ICollection<Insemination> Inseminations { get; set; }
    }
}
