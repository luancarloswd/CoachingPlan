using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class EvaluationCoacheeSpecs
    {
        public static Expression<Func<EvaluationCoachee, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<EvaluationCoachee, bool>> GetOneBySession(Guid idSession)
        {
            return x => x.IdSession == idSession;
        }
        public static Expression<Func<EvaluationCoachee, bool>> GetOneByCoachee(Guid idCoachee)
        {
            return x => x.IdCoachee == idCoachee;
        }
        public static Expression<Func<EvaluationCoachee, bool>> GetOneByCoacheeAndSession(Guid idCoachee, Guid idSession)
        {
            return x => x.IdCoachee == idCoachee && x.IdSession == idSession;
        }
    }
}
