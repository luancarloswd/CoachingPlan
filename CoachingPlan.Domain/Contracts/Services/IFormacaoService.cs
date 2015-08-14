using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IFormacaoService : IDisposable
    {
        Formation GetOne(Guid id);
        void Register(Formation Formacao);
        void ChageInformation(Guid id, Formation Formacao);
        void Remove(Guid id);
        ICollection<Formation> GetAll(); 
    }
}
