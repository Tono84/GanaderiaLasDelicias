using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class SalaryRecord
    {
        [Key]
        public int SalaryRecordId { get; set; }

        [Required(ErrorMessage = "El empleado es requerido")]
        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha de Pago")]
        public DateTime PaymentDate { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 9999999.99, ErrorMessage = "El monto debe estar entre 0 y 9,999,999.99")]
        [Required(ErrorMessage = "El monto es requerido")]
        [Display(Name = "monto")]
        public decimal Amount { get; set; }


        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El tipo de pago solo debe contener letras.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El tipo de pago es requerido")]
        [Display(Name = "Tipo de pago")]
        public string PaymentType { get; set; } = null!; 

        public virtual Employee? Employee { get; set; } 
    }
}
