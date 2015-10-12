using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class BudgetSpecs
    {
        public static Expression<Func<Budget, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
