using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IPontoForteService : IDisposable
    {
        PontoForte GetOne(Guid id);
        void Register(PontoForte PontoForte);
        void ChageInformation(Guid id, PontoForte PontoForte);
        void Remove(Guid id);
        ICollection<PontoForte> GetAll(); 
    }
}
