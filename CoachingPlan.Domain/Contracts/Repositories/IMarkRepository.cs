using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace MarkingPlan.Domain.Contracts.Repositories
{
    public interface IMarkRepository : IDisposable
    {
        Mark GetOne(Guid id);
        List<Mark> GetAll();
        List<Mark> GetAll(int take, int skip);
        void Create(Mark Mark);
        void Update(Mark Mark);
        void Delete(Mark Mark);
    }
}
