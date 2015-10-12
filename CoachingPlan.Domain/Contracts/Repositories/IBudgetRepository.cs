using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IBudgetRepository : IDisposable
    {
        Budget GetOne(Guid id);
        List<Budget> GetAll();
        List<Budget> GetAllByCoachingProcess(Guid idCoachhingProcess);
        List<Budget> GetAll(int take, int skip);
        void Create(Budget AcctionPlan);
        void Update(Budget Coachee);
        void Delete(Budget Coachee);
    }
}
