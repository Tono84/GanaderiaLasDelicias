using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class SalaryRecord
    {
        public int SalaryRecordId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; } = null!; 

        public virtual Employee? Employee { get; set; } 
    }
}
