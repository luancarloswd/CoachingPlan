using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IFormationRepository : IDisposable
    {
        Formation GetOne(Guid id);
        Formation GetOneByCoach(Guid idCoach);
        List<Formation> GetAll();
        List<Formation> GetAll(int take, int skip);
        void Create(Formation formation);
        void Update(Formation formation);
        void Delete(Formation formation);
        List<Formation> GetAllByCoach(Guid idCoach);
    }
}
