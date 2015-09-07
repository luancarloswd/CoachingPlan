using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace ActionPlaningPlan.Domain.Contracts.Services
{
    public interface IActionPlanService : IDisposable
    {
        ActionPlan GetOne(Guid id);
        void Register(ActionPlan ActionPlan);
        void Remove(Guid id);
        ICollection<ActionPlan> GetAll(); 
    }
}
