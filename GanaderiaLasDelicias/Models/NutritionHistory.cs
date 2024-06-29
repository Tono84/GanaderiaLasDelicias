using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class NutritionHistory
    {
        public int NutritionHisId { get; set; }
        public int NutritionPlanId { get; set; }
        public decimal? DailyProtein { get; set; }
        public decimal? DailySupplement { get; set; }
        public decimal? DailyWater { get; set; }
        public decimal? DailyMinerals { get; set; }
        public decimal? DailyVitamins { get; set; }
        public decimal? DailyCarbs { get; set; }

        public virtual Nutrition NutritionPlan { get; set; } = null!;
    }
}
