using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class QuestionScope
    {
        public static bool CreateQuestionScopeIsValid(this Question question)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(question.TypeReply, Errors.TypeIsRequired),
                            AssertionConcern.AssertArgumentNotNull(question.TypeQuestion, Errors.TypeIsRequired),
                            AssertionConcern.AssertArgumentNotNull(question.Enunciation, Errors.EnuciationIsRequired),
                            AssertionConcern.AssertArgumentLength(question.Enunciation, 2, 256, Errors.InvalidEnunciation)
                );
        }
        public static bool ChangeTypeReplyScopeIsValid(this Question question, ETypeReply typeReply)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(typeReply, Errors.TypeIsRequired)
                );
        }
        public static bool ChangeGroupScopeIsValid(this Question question, string group)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(group, Errors.GroupIsRequired),
                            AssertionConcern.AssertArgumentLength(group, 1, 60, Errors.InvalidGroup)
                );
        }
        public static bool ChangeTypeQuestionScopeIsValid(this Question question, ETypeQuestion typeQuestion)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(typeQuestion, Errors.TypeIsRequired)
                );
        }
        public static bool ChangeEducationScopeIsValid(this Question question, string enunciation)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(question.Enunciation, Errors.EnuciationIsRequired),
                            AssertionConcern.AssertArgumentLength(question.Enunciation, 2, 256, Errors.InvalidEnunciation)
                );
        }
    }
}
