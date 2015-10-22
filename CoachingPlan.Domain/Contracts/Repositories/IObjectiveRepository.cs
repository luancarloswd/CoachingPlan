using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IObjectiveRepository : IDisposable
    {
        Objective GetOne(Guid id);
        List<Objective> GetAll();
        List<Objective> GetAllByActionPlan(Guid idActionPlan);
        List<Objective> GetAll(int take, int skip);
        void Create(Objective Objective);
        void Update(Objective Objective);
        void Delete(Objective Objective);
    }
}
