using CoachingPlan.Domain.Commands.ObjectiveCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IObjectiveApplicationService : IDisposable
    {
        Objective GetOne(Guid id);
        List<Objective> GetAll();
        List<Objective> GetAllByActionPlan(Guid idActionPlan);
        List<Objective> GetAll(int take, int skip);
        Objective Create(CreateObjectiveCommand Objective);
        Objective Update(UpdateObjectiveCommand Objective);
        Objective Delete(Guid idObjective);
        List<Objective> AddToActionPlan(dynamic body);
        void CheckObjectiveRemoved(List<Objective> listObjective, Guid idActionPlan);
    }
}
