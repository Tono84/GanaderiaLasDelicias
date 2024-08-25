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
        public Dictionary<string, int> HealthStatusCounts { get; set; } // Agregado para el gráfico de salud
        public double FatPercentage { get; set; }
        public double ProteinPercentage { get; set; }
        public double LactosePercentage { get; set; }

        public IEnumerable<FeedingDataDto> FeedingData { get; set; } // Asegúrate de agregar esta propiedad
    }

    public class FeedingDataDto
    {
        public string CowName { get; set; }
        public int GrazingHours { get; set; }
    }
}
