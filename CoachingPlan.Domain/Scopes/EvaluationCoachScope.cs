using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;

namespace CoachingPlan.Domain.Scopes
{
    public static class EvaluationCoachScope
    {
        public static bool CreateEvaluationCoachScopeIsValid(this EvaluationCoach evaluationCoach)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(evaluationCoach.IdCoach, Errors.CoachNotFound),
                            AssertionConcern.AssertArgumentNotNull(evaluationCoach.IdSession, Errors.SessionNotFound)
                );
        }
        public static bool ChangeEvaluationScopeIsValid(this EvaluationCoach evaluationCoach, int? evaluation)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(evaluation, Errors.InvalidEvaluation)
                );
        }
    }
}
