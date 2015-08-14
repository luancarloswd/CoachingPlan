using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEspecialidadeService : IDisposable
    {
        Speciality GetOne(Guid id);
        void Register(Speciality Especialidade);
        void ChageInformation(Guid id, Speciality Especialidade);
        void Remove(Guid id);
        ICollection<Speciality> GetAll(); 
    }
}
