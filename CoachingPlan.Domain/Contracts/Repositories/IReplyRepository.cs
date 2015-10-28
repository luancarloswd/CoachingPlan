using CoachingPlan.Domain.Commands.ReplyCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IReplyRepository : IDisposable
    {
        Reply GetOne(Guid id);
        List<Reply> GetAll();
        List<Reply> GetAllByQuestion(Guid id);
        List<Reply> GetAllByQuestionAndStatusOfTrue(Guid id);
        List<Reply> GetAll(int take, int skip);
        void Create(Reply reply);
        void Update(Reply reply);
        void Delete(Reply reply);
    }
}
