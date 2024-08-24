using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeePayments = new HashSet<EmployeePayment>();
            Milkings = new HashSet<Milking>();
            SalaryRecords = new HashSet<SalaryRecord>();
        }

        [Key]
        public int EmployeeId { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; } = null!;

        [Display(Name = "Apellido")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Número de Identificación")]
        public string NatId { get; set; } = null!;

        [Display(Name = "Puesto")]
        public string JobTitle { get; set; } = null!;

        [Display(Name = "Salario")]
        public decimal BaseSalary { get; set; }

        [Display(Name = "Horario")]
        public int ScheduleId { get; set; }

        [Display(Name = "Usuario")]
        public string? AspNetUserId { get; set; }

        [Display(Name = "Estado")]
        public string? Status { get; set; }

        public virtual AspNetUser? AspNetUser { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
        public virtual ICollection<Milking> Milkings { get; set; }
        public virtual ICollection<SalaryRecord> SalaryRecords { get; set; }
    }
}
