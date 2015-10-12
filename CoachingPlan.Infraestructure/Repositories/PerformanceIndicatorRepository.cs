using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class PerformanceIndicatorRepository : IPerformanceIndicatorRepository
    {
        AppDataContext _context;
        public PerformanceIndicatorRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(PerformanceIndicator PerformanceIndicator)
        {
            _context.PerformanceIndicator.Add(PerformanceIndicator);
        }

        public void Delete(PerformanceIndicator PerformanceIndicator)
        {
            _context.PerformanceIndicator.Remove(PerformanceIndicator);
        }

        public List<PerformanceIndicator> GetAll()
        {
            return _context.PerformanceIndicator.ToList();
        }

        public List<PerformanceIndicator> GetAll(int take, int skip)
        {
            return _context.PerformanceIndicator.OrderBy(x => x.Indicator).Skip(skip).Take(take).ToList();
        }

        public PerformanceIndicator GetOne(Guid id)
        {
            return _context.PerformanceIndicator.Where(PerformanceIndicatorSpecs.GetOne(id)).FirstOrDefault();
        }

        public List<PerformanceIndicator> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _context.PerformanceIndicator.Where(PerformanceIndicatorSpecs.GetAllByCoachingProcess(idCoachingProcess)).ToList();
        }

        public void Update(PerformanceIndicator PerformanceIndicator)
        {
            _context.Entry<PerformanceIndicator>(PerformanceIndicator).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
