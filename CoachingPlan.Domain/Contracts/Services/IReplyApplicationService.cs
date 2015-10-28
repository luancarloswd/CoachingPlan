using CoachingPlan.Domain.Commands.ReplyCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IReplyApplicationService : IDisposable
    {
        Reply GetOne(Guid id);
        List<Reply> GetAll();
        List<Reply> GetAllByQuestion(Guid id);
        List<Reply> GetAll(int take, int skip);
        Reply Create(CreateReplyCommand command);
        Reply Update(UpdateReplyCommand command);
        Reply Delete(Guid idReply);
        void CheckReplyRemovedOfQuestion(List<Reply> listReply, Guid idQuestion);
        List<Reply> AddReplys(dynamic body);
    }
}
