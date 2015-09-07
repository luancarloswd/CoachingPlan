using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace FormationingPlan.Domain.Contracts.Repositories
{
    public interface IFormationRepository : IDisposable
    {
        Formation GetOne(Guid id);
        List<Formation> GetAll();
        List<Formation> GetAll(int take, int skip);
        void Create(Formation Formation);
        void Update(Formation Formation);
        void Delete(Formation Formation);
    }
}
