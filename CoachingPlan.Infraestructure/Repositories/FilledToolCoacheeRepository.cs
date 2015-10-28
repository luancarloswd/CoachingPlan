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
    public class FilledToolCoacheeRepository : IFilledToolCoacheeRepository
    {
        AppDataContext _context;
        public FilledToolCoacheeRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(FilledToolCoachee FilledTool)
        {
            _context.FilledToolCoachee.Add(FilledTool);
        }

        public void Delete(FilledToolCoachee FilledTool)
        {
            _context.FilledToolCoachee.Remove(FilledTool);
        }

        public List<FilledToolCoachee> GetAll()
        {
            return _context.FilledToolCoachee.ToList();
        }

        public List<FilledToolCoachee> GetAll(int take, int skip)
        {
            return _context.FilledToolCoachee.OrderBy(x => x.EvaluationDate).Skip(skip).Take(take).ToList();
        }

        public FilledToolCoachee GetOne(Guid id)
        {
            return _context.FilledToolCoachee.Where(FilledToolCoacheeSpecs.GetOne(id)).Include(x => x.EvaluationTool).Include(x=> x.Coachee).FirstOrDefault();
        }

        public void Update(FilledToolCoachee FilledTool)
        {
            _context.Entry<FilledToolCoachee>(FilledTool).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
