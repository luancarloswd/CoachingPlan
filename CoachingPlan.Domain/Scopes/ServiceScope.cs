using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class ServiceScope
    {
        public static bool CreateServiceScopeIsValid(this Service service)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(service.Name, Errors.NameIsRequired),
                            AssertionConcern.AssertArgumentLength(service.Name, 2, 60, Errors.InvalidName),
                            AssertionConcern.AssertArgumentNotNull(service.Value, Errors.ValueIsRequired)
                );
        }
        public static bool ChangeNameScopeIsValid(this Service service, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(name, Errors.NameIsRequired),
                           AssertionConcern.AssertArgumentLength(name, 2, 60, Errors.InvalidName)
                );
        }
        public static bool ChangeValueScopeIsValid(this Service service, float value)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(value, Errors.ValueIsRequired)
                );
        }
    }
}
