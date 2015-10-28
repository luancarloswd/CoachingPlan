using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class FilledToolCoacheeSpecs
    {
        public static Expression<Func<FilledToolCoachee, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
