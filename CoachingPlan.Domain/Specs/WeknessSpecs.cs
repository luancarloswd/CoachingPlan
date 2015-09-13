using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class WeaknessSpecs
    {
        public static Expression<Func<Weakness, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Weakness, bool>> GetOneByCoachee(Guid idCoachee)
        {
            return x => x.IdCoachee == idCoachee;
        }
    }
}
