using CoachingPlan.Domain.Commands.SpecialityCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ISpecialityApplicationService : IDisposable
    {
        Speciality GetOne(Guid id);
        Speciality GetOnebyCoach(Guid idCoach);
        List<Speciality> GetAll();
        List<Speciality> GetAll(int take, int skip);
        Speciality Create(CreateSpecialityCommand formation);
        Speciality Update(ChangeSpecialityCommand formation);
        Speciality Delete(Guid id);
        List<Speciality> AddToCoach(dynamic body);
        void CheckSpecialityRemoved(List<Speciality> listSpeciality, Guid idCoach);

    }
}
