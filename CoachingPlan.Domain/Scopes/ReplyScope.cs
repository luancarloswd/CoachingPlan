using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class ReplyScope
    {
        public static bool CreateReplyScopeIsValid(this Reply reply)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(reply.BodyReply, Errors.ReplyIsRequired),
                            AssertionConcern.AssertArgumentLength(reply.BodyReply, 1, 256, Errors.InvalidReply)
                );
        }
        public static bool ChangeReplyScopeIsValid(this Reply reply, string bodyReply)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(bodyReply, Errors.ReplyIsRequired),
                            AssertionConcern.AssertArgumentLength(bodyReply, 1, 256, Errors.InvalidReply)
                );
        }
        public static bool ChangeGroupScopeIsValid(this Reply reply, string group)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(group, Errors.GroupIsRequired),
                            AssertionConcern.AssertArgumentLength(group, 1, 60, Errors.InvalidGroup)
                );
        }
    }
}
