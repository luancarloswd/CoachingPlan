using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class StrongPointRepository : IStrongPointRepository
    {
        AppDataContext _context;
        public StrongPointRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(StrongPoint StrongPoint)
        {
            _context.StrongPoint.Add(StrongPoint);
        }

        public void Delete(StrongPoint strongPoint)
        {
            _context.StrongPoint.Remove(strongPoint);
        }

        public List<StrongPoint> GetAll()
        {
            return _context.StrongPoint.ToList();
        }

        public List<StrongPoint> GetAll(int take, int skip)
        {
            return _context.StrongPoint.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public StrongPoint GetOne(Guid id)
        {
            return _context.StrongPoint.Where(StrongPointSpecs.GetOne(id)).FirstOrDefault();
        }

        public StrongPoint GetOneByCoachee(Guid idCoachee)
        {
            return _context.StrongPoint.Where(StrongPointSpecs.GetOneByCoachee(idCoachee)).FirstOrDefault();
        }

        public void Update(StrongPoint strongPoint)
        {
            _context.Entry<StrongPoint>(strongPoint).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
