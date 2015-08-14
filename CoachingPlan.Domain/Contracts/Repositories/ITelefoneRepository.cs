using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ITelefoneRepository : IDisposable
    {
        Phone GetOne(Guid id);
        List<Phone> GetAll();
        void Create(Phone Telefone);
        void Update(Phone Telefone);
        void Delete(Phone Telefone);
    }
}
