using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class EvaluationScope
    {
        public static bool CreateEvaluationScopeIsValid(this Evaluation evaluation)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(evaluation.Note, Errors.NoteIsRequired)
                );
        }
        public static bool ChangeNoteScopeIsValid(this Evaluation evaluation, float note)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(evaluation.Note, Errors.NoteIsRequired)
                );
        }
    }
}
