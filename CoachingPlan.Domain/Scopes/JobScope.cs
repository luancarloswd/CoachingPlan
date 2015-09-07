using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class JobScope
    {
        public static bool CreateJobScopeIsValid(this Job job)
        {
            return AssertionConcern.IsSatisfiedBy(
                             AssertionConcern.AssertArgumentNotNull(job.StartDate, Errors.DataIsRequired),
                             AssertionConcern.AssertArgumentNotNull(job.VerificationDate, Errors.VerificationDataIsRequired)
                );
        }
        public static bool ChangeStartDateScopeIsValid(this Job job, DateTime startDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(startDate, Errors.DataIsRequired)
                );
        }
        public static bool ChangeVerificationDateScopeIsValid(this Job job, DateTime verificationDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(verificationDate, Errors.VerificationDataIsRequired)
                );
        }
    }
}
