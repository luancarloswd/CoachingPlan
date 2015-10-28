using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class QuestionSpecs
    {
        public static Expression<Func<Question, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Question, bool>> GetAllByEvaluationTool(Guid idEvaluationTool)
        {
            return x => x.IdEvaluationTool == idEvaluationTool;
        }
    }
}
