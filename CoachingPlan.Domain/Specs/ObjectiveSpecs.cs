using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class ObjectiveSpecs
    {
        public static Expression<Func<Objective, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
