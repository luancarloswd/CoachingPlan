using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IFragilidadeService : IDisposable
    {
        Fragilidade GetOne(Guid id);
        void Register(Fragilidade Fragilidade);
        void ChageInformation(Guid id, Fragilidade Fragilidade);
        void Remove(Guid id);
        ICollection<Fragilidade> GetAll(); 
    }
}
