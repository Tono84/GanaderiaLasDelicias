using System;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }

        [Display(Name ="Empleado")]
        public int EmployeeId { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El salario bruto debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 9999999.99, ErrorMessage = "El salario bruto debe estar entre 0 y 9,999.99")]
        [Required(ErrorMessage = "El Salario bruto es requerido")]
        [Display(Name = "Salario Bruto")]
        public decimal GrossSalary { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Las deducciones deben de ser un número decimal con hasta dos decimales.")]
        [Range(0, 9999999.99, ErrorMessage = "Las deducciones deben de estar estar entre 0 y 99.99")]
        [Required(ErrorMessage = "El campo deducciones es requerido")]
        [Display(Name = "Deducciones")]
        public decimal Deductions { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El salario neto debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 9999999.99, ErrorMessage = "El salario neto debe estar entre 0 y 9,999.99")]
        [Required(ErrorMessage = "El Salario neto es requerido")]
                [Display(Name = "Salario Neto")]
        public decimal NetSalary { get; set; }

        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "Las vacaciones usadas deben de ser un número entero.")]
        [Required(ErrorMessage = "El campo de vacaciones usadas es requerido")]
        [Range(0, 999, ErrorMessage = "Las vacaciones utilizadas deben estar entre 0 y 999")]
        [Display(Name = "Vacaciones usadas")]
        public int VacationsUsed { get; set; }



        [Required(ErrorMessage = "La fecha de pago es requerida")]
        [Display(Name = "Fecha de Pago")]
        public DateTime CreatedDate { get; set; }

        public Employee? Employee { get; set; }
    }
}

