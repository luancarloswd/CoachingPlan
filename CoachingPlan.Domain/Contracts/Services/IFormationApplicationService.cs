using CoachingPlan.Domain.Commands.FormationCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IFormationApplicationService : IDisposable
    {
        Formation GetOne(Guid id);
        Formation GetOnebyCoach(Guid idCoach);
        List<Formation> GetAll();
        List<Formation> GetAll(int take, int skip);
        Formation Create(CreateFormationCommand formation);
        Formation Update(ChangeFormationCommand formation);
        Formation Delete(Guid id);
        List<Formation> AddToCoach(dynamic body);
        void CheckFormationRemoved(List<Formation> listFormation, Guid idCoach);
    }
}
