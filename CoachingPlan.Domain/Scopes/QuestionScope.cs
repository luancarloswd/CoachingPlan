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
                            AssertionConcern.AssertArgumentNotNull(question.Education, Errors.EnuciationIsRequired),
                            AssertionConcern.AssertArgumentLength(question.Education, 2, 256, Errors.InvalidEnunciation)
                );
        }
        public static bool ChangeTypeReplyScopeIsValid(this Question question, ETypeReply typeReply)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(typeReply, Errors.TypeIsRequired)
                );
        }
        public static bool ChangeTypeQuestionScopeIsValid(this Question question, ETypeQuestion typeQuestion)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(typeQuestion, Errors.TypeIsRequired)
                );
        }
        public static bool ChangeEducationScopeIsValid(this Question question, string education)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(question.Education, Errors.EnuciationIsRequired),
                            AssertionConcern.AssertArgumentLength(question.Education, 2, 256, Errors.InvalidEnunciation)
                );
        }
    }
}
