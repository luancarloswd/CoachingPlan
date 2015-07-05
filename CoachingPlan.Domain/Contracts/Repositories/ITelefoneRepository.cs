using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ITelefoneRepository : IDisposable
    {
        Telefone GetOne(Guid id);
        List<Telefone> GetAll();
        void Create(Telefone Telefone);
        void Update(Telefone Telefone);
        void Delete(Telefone Telefone);
    }
}
