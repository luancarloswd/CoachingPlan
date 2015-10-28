using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;

namespace CoachingPlan.Domain.Scopes
{
    public static class EvaluationCoacheeScope
    {
        public static bool CreateEvaluationCoacheeScopeIsValid(this EvaluationCoachee evaluationCoachee)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(evaluationCoachee.IdCoachee, Errors.CoacheeNotFound),
                            AssertionConcern.AssertArgumentNotNull(evaluationCoachee.IdSession, Errors.SessionNotFound)
                );
        }
        public static bool ChangeEvaluationScopeIsValid(this EvaluationCoachee evaluationCoach, int? evaluation)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(evaluation, Errors.InvalidEvaluation)
                );
        }
    }
}
