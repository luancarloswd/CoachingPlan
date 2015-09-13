using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ISpecialityRepository : IDisposable
    {
        Speciality GetOne(Guid id);
        Speciality GetOneByCoach(Guid idCoach);
        List<Speciality> GetAll();
        List<Speciality> GetAll(int take, int skip);
        void Create(Speciality speciality);
        void Update(Speciality speciality);
        void Delete(Speciality speciality);
    }
}
