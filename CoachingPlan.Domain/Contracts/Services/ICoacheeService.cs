using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ICoachService : IDisposable
    {
        Coach GetOne(Guid id);
        void Register(Coach Coach);
        void ChageInformation(Guid id, Coach Coach);
        void Remove(Guid id);
        ICollection<Coach> GetAll(); 
    }
}
