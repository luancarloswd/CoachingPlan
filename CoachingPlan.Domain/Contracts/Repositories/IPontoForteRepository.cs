using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPontoForteRepository : IDisposable
    {
        PontoForte GetOne(Guid id);
        List<PontoForte> GetAll();
        void Create(PontoForte PontoForte);
        void Update(PontoForte PontoForte);
        void Delete(PontoForte PontoForte);
    }
}
