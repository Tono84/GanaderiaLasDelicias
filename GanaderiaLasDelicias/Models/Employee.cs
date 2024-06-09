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
        }

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Nombre")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Número de Indetificación")]
        public string NatId { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Titulo de Trabajo")]
        public string JobTitle { get; set; } = null!;

        [Required]
        [Display(Name = "Salario Base")]
        public decimal BaseSalary { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public int ScheduleId { get; set; }


        [Display(Name = "Usuario")]
        public string? AspNetUserId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name= "Estado")]
        public string Status { get; set; }

        [Display(Name = "Usuario")]
        public virtual AspNetUser? AspNetUser { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
        public virtual ICollection<Milking> Milkings { get; set; }
    }
}
