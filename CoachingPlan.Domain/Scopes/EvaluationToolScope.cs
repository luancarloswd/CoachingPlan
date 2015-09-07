using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class EvaluationToolScope
    {
        public static bool CreateEvaluationToolScopeIsValid(this EvaluationTool evaluationTool)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(evaluationTool.Name, Errors.NameIsRequired),
                            AssertionConcern.AssertArgumentLength(evaluationTool.Name, 2, 60, Errors.InvalidName),
                            AssertionConcern.AssertArgumentNotNull(evaluationTool.Type, Errors.TypeIsRequired)
                );
        }
        public static bool ChangeNameScopeIsValid(this EvaluationTool evaluationTool, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(name, Errors.NameIsRequired),
                            AssertionConcern.AssertArgumentLength(name, 2, 60, Errors.InvalidName)
                );
        }
        public static bool ChangeTypeScopeIsValid(this EvaluationTool evaluationTool, ETypeEvaluationTool type)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(evaluationTool.Type, Errors.TypeIsRequired)
                );
        }
    }
}
