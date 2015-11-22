using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ICoacheeRepository : IDisposable
    {
        Coachee GetOne(Guid id);
        Coachee GetOneByUser(string idUser);
        List<Coachee> GetAll();
        List<Coachee> GetAll(int take, int skip);
        void Create(Coachee Coachee);
        void Update(Coachee Coachee);
        void Delete(Coachee Coachee);
        List<Coachee> GetAllIncludeDetails();
        List<Coachee> GetAllIncludePerson();
        Coachee GetOneIncludeDetails(Guid id);
        List<Coachee> GetAllByCoachingProcess(Guid idCoachingProcess);
        Coachee GetOneIncludeCoachingProcess(Guid id);
        List<Coachee> GetAllBySession(Guid idSession);
        List<Coachee> GetAllIncludeProcess();
    }
}
