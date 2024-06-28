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
        public decimal? Protein { get; set; }
        public decimal? Supplement { get; set; }
        public decimal? Water { get; set; }
        public decimal? Minerals { get; set; }
        public decimal? Vitamins { get; set; }
        public decimal? Carbs { get; set; }

        public virtual Herd Cow { get; set; } = null!;
        public virtual ICollection<NutritionHistory> NutritionHistories { get; set; }
    }
}
