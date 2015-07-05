using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEspecialidadeRepository : IDisposable
    {
        Especialidade GetOne(Guid id);
        List<Especialidade> GetAll();
        void Create(Especialidade Especialidade);
        void Update(Especialidade Especialidade);
        void Delete(Especialidade Especialidade);
    }
}
