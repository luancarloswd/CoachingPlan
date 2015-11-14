using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class FilledToolCoacheeScope
    {
        public static bool CreateFilledToolScopeIsValid(this FilledToolCoachee filledTool)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(filledTool.EvaluationDate, Errors.DateIsRequired)
                );
        }
        public static bool ChangeEvaluationDateScopeIsValid(this FilledToolCoachee filledTool, DateTime evaluationDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(evaluationDate, Errors.DateIsRequired),
                              AssertionConcern.AssertArgumentAreEquals(filledTool.EvaluationDate, DateTime.MinValue, Errors.StartDateIsRequired)
                );
        }
    }
}
