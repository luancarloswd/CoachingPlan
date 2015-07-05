using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IPessoaService : IDisposable
    {
        Pessoa GetOne(Guid id);
        void Register(Pessoa Pessoa);
        void ChageInformation(Guid id, Pessoa Pessoa);
        void Remove(Guid id);
        ICollection<Pessoa> GetAll(); 
    }
}
