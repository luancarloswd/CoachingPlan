using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace StrongPointingPlan.Domain.Contracts.Repositories
{
    public interface IStrongPointRepository : IDisposable
    {
        StrongPoint GetOne(Guid id);
        List<StrongPoint> GetAll();
        List<StrongPoint> GetAll(int take, int skip);
        void Create(StrongPoint StrongPoint);
        void Update(StrongPoint StrongPoint);
        void Delete(StrongPoint StrongPoint);
    }
}
