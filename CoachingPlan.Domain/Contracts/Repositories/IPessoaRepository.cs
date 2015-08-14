using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPessoaRepository : IDisposable
    {
        People GetOne(Guid id);
        List<People> GetAll();
        void Create(People Pessoa);
        void Update(People Pessoa);
        void Delete(People Pessoa);
    }
}
