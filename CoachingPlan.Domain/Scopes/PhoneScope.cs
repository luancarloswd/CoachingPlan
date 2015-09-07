using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class PhoneScope
    {
        public static bool CreatePhoneScopeIsValid(this Phone phone)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(phone.DDD, Errors.InvalidDDD),
                            AssertionConcern.AssertArgumentLength(phone.DDD, 2, 2, Errors.InvalidDDD),
                            AssertionConcern.AssertArgumentNotNull(phone.Number, Errors.InvalidPhone),
                            AssertionConcern.AssertArgumentLength(phone.Number, 8, 8, Errors.InvalidPhone)
                );
        }
        public static bool ChangeDDDScopeIsValid(this Phone phone, string ddd)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(ddd, Errors.InvalidDDD),
                            AssertionConcern.AssertArgumentLength(ddd, 2, 2, Errors.InvalidDDD)
                );
        }
        public static bool ChangeNumberScopeIsValid(this Phone phone, string number)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(phone.Number, Errors.InvalidPhone),
                            AssertionConcern.AssertArgumentLength(phone.Number, 8, 8, Errors.InvalidPhone)
                );
        }
    }
}
