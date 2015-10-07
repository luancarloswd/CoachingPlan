using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ICoachingProcessRepository : IDisposable
    {
        CoachingProcess GetOne(Guid id);
        List<CoachingProcess> GetAll();
        List<CoachingProcess> GetAll(int take, int skip);
        void Create(CoachingProcess CoachingProcess);
        void Update(CoachingProcess CoachingProcess);
        void Delete(CoachingProcess CoachingProcess);
    }
}
