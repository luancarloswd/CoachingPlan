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
    public class FilledToolCoachRepository : IFilledToolCoachRepository
    {
        AppDataContext _context;
        public FilledToolCoachRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(FilledToolCoach FilledTool)
        {
            _context.FilledToolCoach.Add(FilledTool);
        }

        public void Delete(FilledToolCoach FilledTool)
        {
            _context.FilledToolCoach.Remove(FilledTool);
        }

        public List<FilledToolCoach> GetAll()
        {
            return _context.FilledToolCoach.ToList();
        }

        public List<FilledToolCoach> GetAll(int take, int skip)
        {
            return _context.FilledToolCoach.OrderBy(x => x.EvaluationDate).Skip(skip).Take(take).ToList();
        }

        public FilledToolCoach GetOne(Guid id)
        {
            return _context.FilledToolCoach.Where(FilledToolCoachSpecs.GetOne(id)).Include(x => x.EvaluationTool.Question.Select(n => n.Reply)).Include(x=> x.Coach).FirstOrDefault();
        }

        public void Update(FilledToolCoach FilledTool)
        {
            _context.Entry<FilledToolCoach>(FilledTool).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
