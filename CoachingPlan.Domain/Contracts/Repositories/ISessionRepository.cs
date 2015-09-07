using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace SessioningPlan.Domain.Contracts.Repositories
{
    public interface ISessionRepository : IDisposable
    {
        Session GetOne(Guid id);
        List<Session> GetAll();
        List<Session> GetAll(int take, int skip);
        void Create(Session Session);
        void Update(Session Session);
        void Delete(Session Session);
    }
}
