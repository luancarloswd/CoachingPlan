using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class WeaknessScope
    {
        public static bool CreateWeaknessScopeIsValid(this Weakness weakness)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(weakness.Name, Errors.InvalidWeakness),
                            AssertionConcern.AssertArgumentLength(weakness.Name, 2, 50, Errors.InvalidWeakness)
                );
        }
        public static bool ChangeNameScopeIsValid(this Weakness weakness, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(weakness.Name, Errors.InvalidWeakness),
                            AssertionConcern.AssertArgumentLength(weakness.Name, 2, 50, Errors.InvalidWeakness)
                );
        }
    }
}
