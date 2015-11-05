using CoachingPlan.Domain.Commands.CoachingProcessCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ICoachingProcessApplicationService : IDisposable
    {
        CoachingProcess GetOne(Guid id);
        List<CoachingProcess> GetAll();
        List<CoachingProcess> GetAll(int take, int skip);
        CoachingProcess Create(CreateCoachingProcessCommand command);
        CoachingProcess Update(UpdateCoachingProcessCommand command);
        CoachingProcess Delete(Guid id);
        List<CoachingProcess> GetAllByService(Guid idService);
        CoachingProcess GetOneIncludeDetails(Guid id);
        List<CoachingProcess> GetAllByCoachee(string idCoachee);
    }
}
