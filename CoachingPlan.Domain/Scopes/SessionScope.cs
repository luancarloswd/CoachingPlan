using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class SessionScope
    {
        public static bool CreateSessionScopeIsValid(this Session session)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(session.Theme, Errors.InvalidTheme),
                            AssertionConcern.AssertArgumentLength(session.Theme, 4, 45, Errors.InvalidTheme),
                            AssertionConcern.AssertArgumentNotNull(session.Date, Errors.DateIsRequired),
                            AssertionConcern.AssertArgumentNotNull(session.StartTime, Errors.StartTimeIsRequired),
                            AssertionConcern.AssertArgumentNotNull(session.EndTime, Errors.EndTimeIsRequired),
                            AssertionConcern.AssertArgumentNotNull(session.Classification, Errors.ClassificationIsRequired)
                );
        }
        public static bool ChangeClassificationScopeIsValid(this Session session, ESessionClassification classification)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(session.Classification, Errors.ClassificationIsRequired)
                );
        }
        public static bool ChangeEndTimeScopeIsValid(this Session session, TimeSpan endTime)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(endTime, Errors.EndTimeIsRequired)
                );
        }
        public static bool ChangeStartTimeScopeIsValid(this Session session, TimeSpan startTime)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(startTime, Errors.StartTimeIsRequired)
                );
        }
        public static bool ChangeDateScopeIsValid(this Session session, DateTime date)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(date, Errors.DateIsRequired)
                );
        }
        public static bool ChangeThemeScopeIsValid(this Session session, string theme)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(theme, Errors.InvalidTheme),
                            AssertionConcern.AssertArgumentLength(theme, 4, 45, Errors.InvalidTheme)
                );
        }

    }
}
