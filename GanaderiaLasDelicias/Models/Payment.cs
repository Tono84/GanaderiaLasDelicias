using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class Payment
    {
        public Payment()
        {
            EmployeePayments = new HashSet<EmployeePayment>();
        }

        public int PayId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Ccss { get; set; }
        public decimal Tax { get; set; }

        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
    }
}
