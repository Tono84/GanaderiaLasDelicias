using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanaderiaLasDelicias.Models
{
    public partial class Payment
    {
        public Payment()
        {
            EmployeePayments = new HashSet<EmployeePayment>();
        }

        [Key]
        public int PayId { get; set; }

        [Display(Name="Fecha de Pago")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "CCSS")]
        public decimal Ccss { get; set; }

        [Display(Name = "Impuestos sobre el salario")]
        public decimal Tax { get; set; }

        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
    }
}
