using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class EvaluationToolSpecs
    {
        public static Expression<Func<EvaluationTool, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
