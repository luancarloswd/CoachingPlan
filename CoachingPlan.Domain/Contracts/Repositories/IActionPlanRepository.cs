using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IActionPlanRepository : IDisposable
    {
        ActionPlan GetOne(Guid id);
        ActionPlan GetOneIncludeObjective(Guid id);
        List<ActionPlan> GetAll();
        List<ActionPlan> GetAllByCoacingProcess(Guid idCoachingProcess);
        List<ActionPlan> GetAll(int take, int skip);
        void Create(ActionPlan AcctionPlan);
        void Update(ActionPlan Coachee);
        void Delete(ActionPlan Coachee);
    }
}
