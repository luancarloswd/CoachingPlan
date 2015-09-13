using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class WeaknessRepository : IWeaknessRepository
    {
        AppDataContext _context;
        public WeaknessRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Weakness weakness)
        {
            _context.Weakness.Add(weakness);
        }

        public void Delete(Weakness weakness)
        {
            _context.Weakness.Remove(weakness);
        }

        public List<Weakness> GetAll()
        {
            return _context.Weakness.ToList();
        }

        public List<Weakness> GetAll(int take, int skip)
        {
            return _context.Weakness.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public Weakness GetOne(Guid id)
        {
            return _context.Weakness.Where(WeaknessSpecs.GetOne(id)).FirstOrDefault();
        }

        public Weakness GetOneByCoachee(Guid idCoachee)
        {
            return _context.Weakness.Where(WeaknessSpecs.GetOneByCoachee(idCoachee)).FirstOrDefault();
        }

        public void Update(Weakness weakness)
        {
            _context.Entry<Weakness>(weakness).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
