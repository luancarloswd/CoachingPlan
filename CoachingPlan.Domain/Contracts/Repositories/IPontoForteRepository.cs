using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPontoForteRepository : IDisposable
    {
        StrongPoint GetOne(Guid id);
        List<StrongPoint> GetAll();
        void Create(StrongPoint PontoForte);
        void Update(StrongPoint PontoForte);
        void Delete(StrongPoint PontoForte);
    }
}
