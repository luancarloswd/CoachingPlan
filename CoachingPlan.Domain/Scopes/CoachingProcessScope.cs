using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class CoachingProcssScope
    {
        public static bool CreateCoachingProcessScopeIsValid(this CoachingProcess coachingProcess)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(coachingProcess.StartDate, Errors.StartDateIsRequired),
                            AssertionConcern.AssertArgumentNotNull(coachingProcess.Mode, Errors.ModeIsRequired),
                            AssertionConcern.AssertArgumentNotNull(coachingProcess.Name, Errors.NameIsRequired)
                );
        }
        public static bool ChangeNameScopeIsValid(this CoachingProcess coachingProcess, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(name, Errors.NameIsRequired)
                );
        }
        public static bool ChangeEndDateScopeIsValid(this CoachingProcess coachingProcess, DateTime endDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentIsGreaterOrEqualThan(endDate, coachingProcess.StartDate, Errors.StartDateIsRequired)
                );
        }
        public static bool ChangeStartDateScopeIsValid(this CoachingProcess coachingProcess, DateTime startDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(startDate, Errors.StartDateIsRequired)
                );
        }
        public static bool ChangeModeScopeIsValid(this CoachingProcess coachingProcess, EModeProcess mode)
        {
            return AssertionConcern.IsSatisfiedBy(
                           AssertionConcern.AssertArgumentNotNull(mode, Errors.ModeIsRequired)
                );
        }
    }
}
