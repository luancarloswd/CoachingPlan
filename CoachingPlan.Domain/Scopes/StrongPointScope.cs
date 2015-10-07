using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class StrongPointScope
    {
        public static bool CreateStrongPointScopeIsValid(this StrongPoint strongPoint)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(strongPoint.Name, Errors.InvalidStrongPoint),
                            AssertionConcern.AssertArgumentLength(strongPoint.Name, 2, 50, Errors.InvalidStrongPoint),
                            AssertionConcern.AssertArgumentNotNull(strongPoint.ClassStrongPoint, Errors.InvalidClassStrongPoint)
                );
        }
        public static bool ChangeNameScopeIsValid(this StrongPoint strongPoint, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(name, Errors.InvalidStrongPoint),
                           AssertionConcern.AssertArgumentLength(name, 2, 50, Errors.InvalidStrongPoint)
                );
        }
        public static bool ChangeClassScopeIsValid(this StrongPoint strongPoint, EClassStrongPoint classStrongPoint)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(classStrongPoint, Errors.InvalidClassStrongPoint)
                );
        }
    }
}
