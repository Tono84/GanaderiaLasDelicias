using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class EmployeePayment
    {
        public int EmployeePaymentId { get; set; }
        public int VacationsUsed { get; set; }
        public decimal NetPay { get; set; }
        public int EmployeeId { get; set; }
        public int PaymentId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
    }
}
