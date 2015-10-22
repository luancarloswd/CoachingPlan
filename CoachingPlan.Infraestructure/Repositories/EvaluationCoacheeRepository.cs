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
    public class EvaluationCoacheeRepository : IEvaluationCoacheeRepository
    {
        AppDataContext _context;
        public EvaluationCoacheeRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(EvaluationCoachee evaluation)
        {
            _context.EvaluationCoachee.Add(evaluation);
        }

        public void Delete(EvaluationCoachee evaluation)
        {
            _context.EvaluationCoachee.Remove(evaluation);
        }

        public List<EvaluationCoachee> GetAll()
        {
            return _context.EvaluationCoachee.ToList();
        }

        public List<EvaluationCoachee> GetAll(int take, int skip)
        {
            return _context.EvaluationCoachee.OrderBy(x => x.Evaluation).Skip(skip).Take(take).ToList();
        }

        public EvaluationCoachee GetOne(Guid id)
        {
            return _context.EvaluationCoachee.Where(EvaluationCoacheeSpecs.GetOne(id)).Include(x => x.Coachee.User.Person).FirstOrDefault();
        }

        public List<EvaluationCoachee> GetAllBySession(Guid idSession)
        {
            return _context.EvaluationCoachee.Where(EvaluationCoacheeSpecs.GetOneBySession(idSession)).ToList();
        }

        public List<EvaluationCoachee> GetAllByCoachee(Guid idCoachee)
        {
            return _context.EvaluationCoachee.Where(EvaluationCoacheeSpecs.GetOneByCoachee(idCoachee)).ToList();
        }

        public List<EvaluationCoachee> GetAllByCoacheeAndSession(Guid idCoachee, Guid idSession)
        {
            return _context.EvaluationCoachee.Where(x => x.IdCoachee == idCoachee && x.IdSession == idSession).ToList();
        }

        public void Update(EvaluationCoachee Evaluation)
        {
            _context.Entry<EvaluationCoachee>(Evaluation).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
