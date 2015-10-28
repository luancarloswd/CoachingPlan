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
    public class EvaluationToolRepository : IEvaluationToolRepository
    {
        AppDataContext _context;
        public EvaluationToolRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(EvaluationTool EvaluationTool)
        {
            _context.EvaluationTool.Add(EvaluationTool);
        }

        public void Delete(EvaluationTool EvaluationTool)
        {
            _context.EvaluationTool.Remove(EvaluationTool);
        }

        public List<EvaluationTool> GetAll()
        {
            return _context.EvaluationTool.ToList();
        }
        public List<EvaluationTool> GetAllIncludeDetails()
        {
            return _context.EvaluationTool.Include(x => x.Question.Select(y => y.Reply)).ToList();
        }
        public List<EvaluationTool> GetAllByCoach(Guid id)
        {
            return _context.EvaluationTool.Where(x => x.Coach.FirstOrDefault(y => y.Id == id).Id == id).ToList();
        }

        public List<EvaluationTool> GetAllByCoachee(Guid id)
        {
            return _context.EvaluationTool.Where(x => x.FilledToolCoachee.FirstOrDefault(y => y.IdCoachee == id).Id == id).ToList();
        }
        public List<EvaluationTool> GetAll(int take, int skip)
        {
            return _context.EvaluationTool.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public EvaluationTool GetOne(Guid id)
        {
            return _context.EvaluationTool.Where(EvaluationToolSpecs.GetOne(id)).Include(x => x.Question.Select(y => y.Reply)).Include(x=> x.Coach).FirstOrDefault();
        }

        public EvaluationTool GetOneIncludeFilledTool(Guid id)
        {
            return _context.EvaluationTool.Where(EvaluationToolSpecs.GetOne(id)).Include(x => x.FilledToolCoach).Include(x => x.FilledToolCoachee).FirstOrDefault();
        }

        public void Update(EvaluationTool EvaluationTool)
        {
            _context.Entry<EvaluationTool>(EvaluationTool).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
