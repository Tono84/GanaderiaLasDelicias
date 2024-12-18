﻿using System;
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

    
        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo debe contener letras.")]
        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name="Nombre")]
        public string Name { get; set; } = null!;


        [StringLength(15)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El apellido solo debe contener letras.")]
        [Required(ErrorMessage = "El apellido es requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; } = null!;

        [MaxLength(10,ErrorMessage ="No introduzca más de 10 valores")]
        [Required(ErrorMessage = "El número de identificación es requerido")]
        [Display(Name = "Número de Identificación")]
        public string NatId { get; set; } = null!;

        [StringLength(10)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El puesto solo debe contener letras.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El puesto es requerido")]
        [Display(Name = "Puesto")]
        public string JobTitle { get; set; } = null!;

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El salario debe ser un número decimal con hasta dos decimales.")]
        [Range(0, 9999999.99, ErrorMessage = "El salario debe estar entre 0 y 9,999.99")]
        [Required(ErrorMessage = "El Salario es requerido")]
        [Display(Name = "Salario")]
        public decimal? BaseSalary { get; set; }

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

        public virtual Schedule? schedule { get; set; }
    }
}
