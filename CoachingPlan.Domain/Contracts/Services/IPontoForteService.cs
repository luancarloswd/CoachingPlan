using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IPontoForteService : IDisposable
    {
        StrongPoint GetOne(Guid id);
        void Register(StrongPoint PontoForte);
        void ChageInformation(Guid id, StrongPoint PontoForte);
        void Remove(Guid id);
        ICollection<StrongPoint> GetAll(); 
    }
}
