using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IFragilidadeService : IDisposable
    {
        Weakness GetOne(Guid id);
        void Register(Weakness Fragilidade);
        void ChageInformation(Guid id, Weakness Fragilidade);
        void Remove(Guid id);
        ICollection<Weakness> GetAll(); 
    }
}
