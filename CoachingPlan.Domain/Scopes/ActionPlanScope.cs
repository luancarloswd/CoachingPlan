using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;

namespace CoachingPlan.Domain.Scopes
{
    public static class ActionPlanScope
    {
        public static bool CreateActionPlanScopeIsValid(this ActionPlan actionPlan)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(actionPlan.Description, Errors.InvalidDescription)
                );
        }
        public static bool ChangeDescriptionScopeIsValid(this ActionPlan actionPlan, string description)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(description, Errors.InvalidDescription)
                );
        }
    }
}
