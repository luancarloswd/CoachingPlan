using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPhoneRepository : IDisposable
    {
        Phone GetOne(Guid id);
        Phone GetOnebyPerson(Guid idPerson);
        List<Phone> GetAll();
        List<Phone> GetAll(int take, int skip);
        void Create(Phone phone);
        void Update(Phone phone);
        void Delete(Phone phone);
    }
}
