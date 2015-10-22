using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class JobSpecs
    {
        public static Expression<Func<Job, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
