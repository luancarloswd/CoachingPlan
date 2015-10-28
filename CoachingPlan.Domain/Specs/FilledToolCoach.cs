using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class FilledToolCoachSpecs
    {
        public static Expression<Func<FilledToolCoach, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
