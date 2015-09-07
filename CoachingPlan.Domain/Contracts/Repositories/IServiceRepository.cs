using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace ServiceingPlan.Domain.Contracts.Repositories
{
    public interface IServiceRepository : IDisposable
    {
        Service GetOne(Guid id);
        List<Service> GetAll();
        List<Service> GetAll(int take, int skip);
        void Create(Service Service);
        void Update(Service Service);
        void Delete(Service Service);
    }
}
