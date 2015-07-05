using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ITelefoneService : IDisposable
    {
        Telefone GetOne(Guid id);
        void Register(Telefone Telefone);
        void ChageInformation(Guid id, Telefone Telefone);
        void Remove(Guid id);
        ICollection<Telefone> GetAll(); 
    }
}
