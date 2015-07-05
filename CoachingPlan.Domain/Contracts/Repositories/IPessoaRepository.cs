using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPessoaRepository : IDisposable
    {
        Pessoa GetOne(Guid id);
        List<Pessoa> GetAll();
        void Create(Pessoa Pessoa);
        void Update(Pessoa Pessoa);
        void Delete(Pessoa Pessoa);
    }
}
