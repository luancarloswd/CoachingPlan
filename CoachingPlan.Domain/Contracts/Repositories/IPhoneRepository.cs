using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace PhoneingPlan.Domain.Contracts.Repositories
{
    public interface IPhoneRepository : IDisposable
    {
        Phone GetOne(Guid id);
        List<Phone> GetAll();
        List<Phone> GetAll(int take, int skip);
        void Create(Phone Phone);
        void Update(Phone Phone);
        void Delete(Phone Phone);
    }
}
