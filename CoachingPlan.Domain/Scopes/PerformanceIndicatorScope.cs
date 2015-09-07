using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class PerformanceIndicatorScope
    {
        public static bool CreatePerformanceIndicatorScopeIsValid(this PerformanceIndicator performanceIndicator)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(performanceIndicator.Indicator, Errors.IndicatorIsRequired),
                                        AssertionConcern.AssertArgumentLength(performanceIndicator.Indicator, 2, 50, Errors.InvalidIndicator)
                );
        }
        public static bool ChangeIndicatorScopeIsValid(this PerformanceIndicator performanceIndicator, string indicator)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(indicator, Errors.IndicatorIsRequired),
                                        AssertionConcern.AssertArgumentLength(indicator, 2, 50, Errors.InvalidIndicator)
                );
        }
    }
}
