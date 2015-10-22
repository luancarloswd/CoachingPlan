using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IJobRepository : IDisposable
    {
        Job GetOne(Guid id);
        List<Job> GetAll();
        List<Job> GetAllByMark(Guid idMark);
        List<Job> GetAllBySession(Guid idSession);
        List<Job> GetAll(int take, int skip);
        void Create(Job Job);
        void Update(Job Job);
        void Delete(Job Job);
    }
}
