using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IFormacaoService : IDisposable
    {
        Formacao GetOne(Guid id);
        void Register(Formacao Formacao);
        void ChageInformation(Guid id, Formacao Formacao);
        void Remove(Guid id);
        ICollection<Formacao> GetAll(); 
    }
}
