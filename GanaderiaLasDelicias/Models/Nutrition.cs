using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class Nutrition
    {
        public Nutrition()
        {
            NutritionHistories = new HashSet<NutritionHistory>();
        }

        public int NutritionPlanId { get; set; }
        public int CowId { get; set; }
        public double? Protein { get; set; }
        public double? Supplement { get; set; }
        public double? Water { get; set; }
        public double? Minerals { get; set; }
        public double? Vitamins { get; set; }
        public double? Carbs { get; set; }

        public virtual Herd Cow { get; set; } = null!;
        public virtual ICollection<NutritionHistory> NutritionHistories { get; set; }
    }
}
