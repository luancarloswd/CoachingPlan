using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class CoachingProcessSpecs
    {
        public static Expression<Func<CoachingProcess, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
