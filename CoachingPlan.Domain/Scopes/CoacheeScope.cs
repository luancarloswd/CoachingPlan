using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;

namespace CoachingPlan.Domain.Scopes
{
    public static class CoacheeScope
    {
        public static bool CreateCoacheeScopeIsValid(this Coachee coachee)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(coachee.Profession, Errors.InvalidProfession),
                            AssertionConcern.AssertArgumentLength(coachee.Profession, 2, 25, Errors.InvalidProfession)
                );
        }
        public static bool ChangeProfessionScopeIsValid(this Coachee coachee, string profession)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(profession, Errors.InvalidProfession),
                           AssertionConcern.AssertArgumentLength(profession, 2, 25, Errors.InvalidProfession)
                );
        }
    }
}
