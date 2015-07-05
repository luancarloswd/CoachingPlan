using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IFragilidadeRepository : IDisposable
    {
        Fragilidade GetOne(Guid id);
        List<Fragilidade> GetAll();
        void Create(Fragilidade Fragilidade);
        void Update(Fragilidade Fragilidade);
        void Delete(Fragilidade Fragilidade);
    }
}
