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
                                        AssertionConcern.AssertArgumentNotNull(message.Date, Errors.DateIsRequired),
                                        AssertionConcern.AssertArgumentNotNull(message.BodyMessage, Errors.BodyMessageIsRequired),
                                        AssertionConcern.AssertArgumentNotNull(message.Destination, Errors.DestinationIsRequired)
                );
        }
    }
}
