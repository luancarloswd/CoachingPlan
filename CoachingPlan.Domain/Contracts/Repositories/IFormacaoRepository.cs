using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IFormacaoRepository : IDisposable
    {
        Formation GetOne(Guid id);
        List<Formation> GetAll();
        void Create(Formation Formacao);
        void Update(Formation Formacao);
        void Delete(Formation Formacao);
    }
}
