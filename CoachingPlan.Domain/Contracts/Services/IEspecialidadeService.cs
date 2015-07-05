using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEspecialidadeService : IDisposable
    {
        Especialidade GetOne(Guid id);
        void Register(Especialidade Especialidade);
        void ChageInformation(Guid id, Especialidade Especialidade);
        void Remove(Guid id);
        ICollection<Especialidade> GetAll(); 
    }
}
