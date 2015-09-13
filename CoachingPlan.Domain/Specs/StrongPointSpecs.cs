using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class StrongPointSpecs
    {
        public static Expression<Func<StrongPoint, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<StrongPoint, bool>> GetOneByCoachee(Guid idCoachee)
        {
            return x => x.IdCoachee == idCoachee;
        }
    }
}
