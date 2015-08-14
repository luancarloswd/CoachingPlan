using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEspecialidadeRepository : IDisposable
    {
        Speciality GetOne(Guid id);
        List<Speciality> GetAll();
        void Create(Speciality Especialidade);
        void Update(Speciality Especialidade);
        void Delete(Speciality Especialidade);
    }
}
