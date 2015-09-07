using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ICoacheeRepository : IDisposable
    {
        Coachee GetOne(Guid id);
        Coachee GetOneInclude(Guid id);
        List<Coachee> GetAll();
        List<Coachee> GetAll(int take, int skip);
        void Create(Coachee Coachee);
        void Update(Coachee Coachee);
        void Delete(Coachee Coachee);
    }
}
