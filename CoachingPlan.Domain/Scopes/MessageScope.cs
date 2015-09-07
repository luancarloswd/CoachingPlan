using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class MessageScope
    {
        public static bool CreateMessageScopeIsValid(this Message message)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(message.Subject, Errors.SujectIsRequired),
                                        AssertionConcern.AssertArgumentLength(message.Subject, 4, 50, Errors.InvalidSubject),
                                        AssertionConcern.AssertArgumentNotNull(message.Date, Errors.DateIsRequired),
                                        AssertionConcern.AssertArgumentNotNull(message.BodyMessage, Errors.BodyMessageIsRequired),
                                        AssertionConcern.AssertArgumentNotNull(message.Destination, Errors.DestinationIsRequired)
                );
        }
        public static bool ChangeSubjectScopeIsValid(this Message message, string subject)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(subject, Errors.SujectIsRequired),
                                        AssertionConcern.AssertArgumentLength(subject, 4, 50, Errors.InvalidSubject)
                );
        }
        public static bool ChangeDateScopeIsValid(this Message message, DateTime date)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(date, Errors.DateIsRequired)
                );
        }
        public static bool ChangeBodyMessageScopeIsValid(this Message message, string bodyMessage)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(bodyMessage, Errors.BodyMessageIsRequired)
                );
        }
        public static bool ChangeDestinationScopeIsValid(this Message message, Guid destination)
        {
            return AssertionConcern.IsSatisfiedBy(
                                        AssertionConcern.AssertArgumentNotNull(destination, Errors.DestinationIsRequired)
                );
        }
    }
}
