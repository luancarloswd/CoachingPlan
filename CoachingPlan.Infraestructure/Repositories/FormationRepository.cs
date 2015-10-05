using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class FormationRepository : IFormationRepository
    {
        AppDataContext _context;
        public FormationRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Formation formation)
        {
            _context.Formation.Add(formation);
        }

        public void Delete(Formation formation)
        {
            _context.Formation.Remove(formation);
        }

        public List<Formation> GetAll()
        {
            return _context.Formation.ToList();
        }

        public List<Formation> GetAll(int take, int skip)
        {
            return _context.Formation.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public Formation GetOne(Guid id)
        {
            return _context.Formation.Where(FormationSpecs.GetOne(id)).FirstOrDefault();
        }

        public Formation GetOneByCoach(Guid idCoach)
        {
            return _context.Formation.Where(FormationSpecs.GetOneByCoach(idCoach)).FirstOrDefault();
        }

        public List<Formation> GetAllByCoach(Guid idCoach)
        {
            return _context.Formation.Where(FormationSpecs.GetOneByCoach(idCoach)).ToList();
        }

        public void Update(Formation formation)
        {
            _context.Entry<Formation>(formation).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
