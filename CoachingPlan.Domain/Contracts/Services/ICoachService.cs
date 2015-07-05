using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ICoacheeService : IDisposable
    {
        Coachee GetOne(Guid id);
        void Register(Coachee Coachee);
        void ChageInformation(Guid id, Coachee Coachee);
        void Remove(Guid id);
        ICollection<Coachee> GetAll(); 
    }
}
