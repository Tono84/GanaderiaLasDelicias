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


        [Display(Name = "Salario Bruto")]
        public decimal GrossSalary { get; set; }

        [Display(Name = "Deducciones")]
        public decimal Deductions { get; set; }


        [Display(Name = "Salario Neto")]
        public decimal NetSalary { get; set; }


        [Display(Name = "Vacaciones usadas")]
        public int VacationsUsed { get; set; }


        [Display(Name = "Fecha de Pago")]
        public DateTime CreatedDate { get; set; }

        public Employee? Employee { get; set; }
    }
}

