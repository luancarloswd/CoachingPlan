using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IFormacaoRepository : IDisposable
    {
        Formacao GetOne(Guid id);
        List<Formacao> GetAll();
        void Create(Formacao Formacao);
        void Update(Formacao Formacao);
        void Delete(Formacao Formacao);
    }
}
