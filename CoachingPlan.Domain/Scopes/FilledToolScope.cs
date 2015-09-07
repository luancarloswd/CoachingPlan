using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class FilledToolScope
    {
        public static bool CreateFilledToolScopeIsValid(this FilledTool filledTool)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(filledTool.EvaluationDate, Errors.DateIsRequired)
                );
        }
        public static bool ChangeEvaluationDateScopeIsValid(this FilledTool filledTool, DateTime evaluationDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(evaluationDate, Errors.DateIsRequired)
                );
        }
    }
}
