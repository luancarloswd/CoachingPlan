using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class ObjectiveRepository : IObjectiveRepository
    {
        AppDataContext _context;
        public ObjectiveRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Objective Objective)
        {
            _context.Objective.Add(Objective);
        }

        public void Delete(Objective Objective)
        {
            _context.Objective.Remove(Objective);
        }

        public List<Objective> GetAll()
        {
            return _context.Objective.ToList();
        }

        public List<Objective> GetAll(int take, int skip)
        {
            return _context.Objective.OrderBy(x => x.Description).Skip(skip).Take(take).ToList();
        }

        public Objective GetOne(Guid id)
        {
            return _context.Objective.Where(ObjectiveSpecs.GetOne(id)).FirstOrDefault();
        }

        public Objective GetOneIncludeActionPlan(Guid id)
        {
            return _context.Objective.Where(ObjectiveSpecs.GetOne(id)).Include(x => x.ActionPlan).FirstOrDefault();
        }

        public void Update(Objective Objective)
        {
            _context.Entry<Objective>(Objective).State = EntityState.Modified;
        }

        public List<Objective> GetAllByActionPlan(Guid idActionPlan)
        {
            return _context.Objective.Where(x => x.IdActionPlan == idActionPlan).ToList();
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
