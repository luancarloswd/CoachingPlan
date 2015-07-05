using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ICoachRepository : IDisposable
    {
        Coach GetOne(Guid id);
        List<Coach> GetAll();
        void Create(Coach Coach);
        void Update(Coach Coach);
        void Delete(Coach Coach);
    }
}
