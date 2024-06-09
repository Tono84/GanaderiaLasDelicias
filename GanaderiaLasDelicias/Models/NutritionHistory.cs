using System;
using System.Collections.Generic;

namespace GanaderiaLasDelicias.Models
{
    public partial class NutritionHistory
    {
        public int NutritionHisId { get; set; }
        public int NutritionPlanId { get; set; }
        public double? DailyProtein { get; set; }
        public double? DailySupplement { get; set; }
        public double? DailyWater { get; set; }
        public double? DailyMinerals { get; set; }
        public double? DailyVitamins { get; set; }
        public double? DailyCarbs { get; set; }

        public virtual Nutrition NutritionPlan { get; set; } = null!;
    }
}
