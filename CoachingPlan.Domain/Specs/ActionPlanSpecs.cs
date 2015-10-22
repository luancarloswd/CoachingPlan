using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class ActionPlanSpecs
    {
        public static Expression<Func<ActionPlan, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
