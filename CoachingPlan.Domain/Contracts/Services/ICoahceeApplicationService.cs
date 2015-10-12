using CoachingPlan.Domain.Commands.CoacheeCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ICoacheeApplicationService : IDisposable
    {
        Coachee GetOne(Guid id);
        Coachee GetOneByUser(string idUser);
        List<Coachee> GetAll();
        List<Coachee> GetAll(int take, int skip);
        Coachee Create(CreateCoacheeCommand commandCoachee);
        Coachee Update(UpdateCoacheeCommand commandCoachee);
        Coachee Delete(Guid id);
        List<Coachee> GetAllIncludeDetails();
        List<Coachee> GetAllIncludePerson();
        Coachee GetOneIncludeDetails(Guid id);
        List<Coachee> AddToCoachingProcess(dynamic body);
        void CheckCoacheeRemoved(List<Coachee> listCoachingProcess, Guid idCoachingProcess);
        Coachee GetOneIncludeCoachingProcess(Guid id);
    }
}
