using CoachingPlan.Domain.Commands.ActionPlanCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IActionPlanApplicationService : IDisposable
    {
        ActionPlan GetOne(Guid id);
        List<ActionPlan> GetAll();
        List<ActionPlan> GetAll(int take, int skip);
        ActionPlan Create(CreateActionPlanCommand command);
        ActionPlan Update(UpdateActionPlanCommand command);
        ActionPlan Delete(Guid idCoachingPrcess);
        List<ActionPlan> GetAllByCoachingProcess(Guid idCoachingProcess);
    }
}
