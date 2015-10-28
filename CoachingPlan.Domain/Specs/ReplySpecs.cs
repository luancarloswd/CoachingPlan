using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class ReplySpecs
    {
        public static Expression<Func<Reply, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Reply, bool>> GetAllByQuestion(Guid idQuestion)
        {
            return x => x.IdQuestion == idQuestion;
        }
        public static Expression<Func<Reply, bool>> GetAllByQuestionAndStatusOfTrue(Guid id)
        {
            return x => x.IdQuestion == id && x.Status == true;
        }
    }
}
