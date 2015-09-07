using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class FormationScope
    {
        public static bool CreateFormationScopeIsValid(this Formation formation)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(formation.Name, Errors.InvalidTraining),
                             AssertionConcern.AssertArgumentLength(formation.Name, 2, 45, Errors.InvalidTraining)
                );
        }
        public static bool ChangeNameScopeIsValid(this Formation formation, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(name, Errors.InvalidTraining),
                             AssertionConcern.AssertArgumentLength(name, 2, 45, Errors.InvalidTraining)
                );
        }
    }
}
