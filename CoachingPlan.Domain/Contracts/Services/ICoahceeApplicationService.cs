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
        Coachee Create(CreateCoacheeCommand commandCoach);
        Coachee Update(Coachee coachee);
        Coachee Delete(Guid id);
    }
}
