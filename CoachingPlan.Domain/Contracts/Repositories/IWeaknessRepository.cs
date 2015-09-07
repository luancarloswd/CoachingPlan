using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace WeaknessingPlan.Domain.Contracts.Repositories
{
    public interface IWeaknessRepository : IDisposable
    {
        Weakness GetOne(Guid id);
        List<Weakness> GetAll();
        List<Weakness> GetAll(int take, int skip);
        void Create(Weakness Weakness);
        void Update(Weakness Weakness);
        void Delete(Weakness Weakness);
    }
}
