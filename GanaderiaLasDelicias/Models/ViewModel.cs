using Microsoft.AspNetCore.Mvc.Rendering;

namespace GanaderiaLasDelicias.Models
{
    public class ViewModel
    {
        public class SalaryRecordViewModel
        {
            public IEnumerable<SalaryRecord> SalaryRecords { get; set; }
            public IEnumerable<EmployeePaymentCount> EmployeePaymentsCount { get; set; }
            public SelectList Employees { get; set; }
        }

        public class EmployeePaymentCount
        {
            public string EmployeeName { get; set; }
            public int PaymentsCount { get; set; }
        }
        public class SalaryRecordDetailsViewModel
        {
            public string EmployeeName { get; set; }
            public IEnumerable<SalaryRecord> SalaryRecords { get; set; }
            public List<int> Years { get; set; }
        }


    }
}
