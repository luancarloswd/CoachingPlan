using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IFragilidadeRepository : IDisposable
    {
        Weakness GetOne(Guid id);
        List<Weakness> GetAll();
        void Create(Weakness Fragilidade);
        void Update(Weakness Fragilidade);
        void Delete(Weakness Fragilidade);
    }
}
