using GanaderiaLasDelicias.Controllers;

namespace GanaderiaLasDelicias.Models
{
    public class Severance
    {
        public int EmployeeId { get; set; }
        public int WorkingYears { get; set; }
        public decimal Salary { get; set; }
        public decimal Compensation { get; set; }

        public Employee? employees { get; set; }
    }
}
