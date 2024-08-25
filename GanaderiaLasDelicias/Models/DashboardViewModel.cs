namespace GanaderiaLasDelicias.Models
{
    public class DashboardViewModel
    {
        public int ActiveEmployeesCount { get; set; }
        public int PaymentsCount { get; set; }
        public int CowsCount { get; set; }
        public int PregnantCowsCount { get; set; }
        // Agregar propiedad para los datos del gráfico
        public List<PaymentDataDto> PaymentData { get; set; }

    }
}
