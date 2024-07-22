using System;

namespace GanaderiaLasDelicias.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public int VacationsUsed { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

