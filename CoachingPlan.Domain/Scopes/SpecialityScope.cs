using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class SpecialityScope
    {
        public static bool CreateSpecialityScopeIsValid(this Speciality speciality)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(speciality.Name, Errors.InvalidSpecialty),
                            AssertionConcern.AssertArgumentLength(speciality.Name, 2, 45, Errors.InvalidSpecialty)
                );
        }
        public static bool ChangeNameScopeIsValid(this Speciality speciality, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(name, Errors.InvalidSpecialty),
                            AssertionConcern.AssertArgumentLength(name, 2, 45, Errors.InvalidSpecialty)
                );
        }
    }
}
