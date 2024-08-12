using System;
using System.Collections.Generic;


namespace GanaderiaLasDelicias.Models
{
    public class Bonus
    {
        public List<decimal> Salarios { get; set; } = new List<decimal>(new decimal[13]);
        public decimal Resultado { get; set; }
    }
}
