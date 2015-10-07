using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        AppDataContext _context;
        public ServiceRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Service Service)
        {
            _context.Service.Add(Service);
        }

        public void Delete(Service Service)
        {
            _context.Service.Remove(Service);
        }

        public List<Service> GetAll()
        {
            return _context.Service.ToList();
        }

        public List<Service> GetAll(int take, int skip)
        {
            return _context.Service.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public Service GetOne(Guid id)
        {
            return _context.Service.Where(ServiceSpecs.GetOne(id)).FirstOrDefault();
        }

        public List<Service> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _context.Service.Where(x => x.CoachingProcess.FirstOrDefault(y => y.Id == idCoachingProcess).Id == idCoachingProcess).ToList();
        }

        public void Update(Service Service)
        {
            _context.Entry<Service>(Service).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
