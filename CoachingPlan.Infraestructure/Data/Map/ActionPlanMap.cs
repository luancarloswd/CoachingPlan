using CoachingPlan.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class ActionPlanMap : EntityTypeConfiguration<ActionPlan>
    {
        public ActionPlanMap()
        {
            ToTable("");
        }
    }
}
