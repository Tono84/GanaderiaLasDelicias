using System;
using System.Collections.Generic;

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

        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string NatId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public decimal BaseSalary { get; set; }
        public int ScheduleId { get; set; }
        public string? AspNetUserId { get; set; }
        public string? Status { get; set; }

        public virtual AspNetUser? AspNetUser { get; set; }
        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
        public virtual ICollection<Milking> Milkings { get; set; }
        public virtual ICollection<SalaryRecord> SalaryRecords { get; set; }
    }
}
