using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ICoacheeRepository : IDisposable
    {
        Coachee GetOne(Guid id);
        List<Coachee> GetAll();
        void Create(Coachee Coachee);
        void Update(Coachee Coachee);
        void Delete(Coachee Coachee);
    }
}
