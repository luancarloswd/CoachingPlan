using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class MarkScope
    {
        public static bool CreateMarkScopeIsValid(this Mark mark)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(mark.Description, Errors.InvalidDescription),
                            AssertionConcern.AssertArgumentNotNull(mark.Term, Errors.TermGoalIsRequired)
                );
        }
        public static bool ChangeDescriptionScopeIsValid(this Mark mark, string description)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(description, Errors.InvalidDescription)
                );
        }
        public static bool ChangeTermScopeIsValid(this Mark mark, DateTime term)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(term, Errors.TermGoalIsRequired)
                );
        }
    }
}
