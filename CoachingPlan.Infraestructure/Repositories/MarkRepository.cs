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
    public class MarkRepository : IMarkRepository
    {
        AppDataContext _context;
        public MarkRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Mark Mark)
        {
            _context.Mark.Add(Mark);
        }

        public void Delete(Mark Mark)
        {
            _context.Mark.Remove(Mark);
        }

        public List<Mark> GetAll()
        {
            return _context.Mark.ToList();
        }

        public List<Mark> GetAll(int take, int skip)
        {
            return _context.Mark.OrderBy(x => x.Description).Skip(skip).Take(take).ToList();
        }

        public Mark GetOne(Guid id)
        {
            return _context.Mark.Where(MarkSpecs.GetOne(id)).FirstOrDefault();
        }

        public Mark GetOneIncludeObjective(Guid id)
        {
            return _context.Mark.Where(MarkSpecs.GetOne(id)).Include(x => x.Objective).FirstOrDefault();
        }

        public void Update(Mark Mark)
        {
            _context.Entry<Mark>(Mark).State = EntityState.Modified;
        }

        public List<Mark> GetAllByObjective(Guid idActionPlan)
        {
            return _context.Mark.Where(x => x.IdObjective == idActionPlan).ToList();
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
