using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class MarkSpecs
    {
        public static Expression<Func<Mark, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
