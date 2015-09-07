using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class ObjectiveScope
    {
        public static bool CreateObjectiveScopeIsValid(this Objective objective)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(objective.Description, Errors.InvalidDescription),
                                        AssertionConcern.AssertArgumentNotNull(objective.Term, Errors.TermGoalIsRequired)
                );
        }
        public static bool ChangeDescriptionScopeIsValid(this Objective objective, string description)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(description, Errors.InvalidDescription)
                );
        }
        public static bool ChangeTermGoalScopeIsValid(this Objective objective, DateTime term)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(term, Errors.TermGoalIsRequired)
                );
        }
    }
}
