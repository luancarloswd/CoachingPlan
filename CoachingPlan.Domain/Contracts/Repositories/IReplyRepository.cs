using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace ReplyingPlan.Domain.Contracts.Repositories
{
    public interface IReplyRepository : IDisposable
    {
        Reply GetOne(Guid id);
        List<Reply> GetAll();
        List<Reply> GetAll(int take, int skip);
        void Create(Reply Reply);
        void Update(Reply Reply);
        void Delete(Reply Reply);
    }
}
