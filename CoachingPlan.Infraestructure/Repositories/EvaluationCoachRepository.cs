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
    public class EvaluationCoachRepository : IEvaluationCoachRepository
    {
        AppDataContext _context;
        public EvaluationCoachRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(EvaluationCoach evaluation)
        {
            _context.EvaluationCoach.Add(evaluation);
        }

        public void Delete(EvaluationCoach evaluation)
        {
            _context.EvaluationCoach.Remove(evaluation);
        }

        public List<EvaluationCoach> GetAll()
        {
            return _context.EvaluationCoach.ToList();
        }

        public List<EvaluationCoach> GetAll(int take, int skip)
        {
            return _context.EvaluationCoach.OrderBy(x => x.Evaluation).Skip(skip).Take(take).ToList();
        }

        public EvaluationCoach GetOne(Guid id)
        {
            return _context.EvaluationCoach.Where(EvaluationCoachSpecs.GetOne(id)).Include(x => x.Coach.User.Person).FirstOrDefault();
        }

        public List<EvaluationCoach> GetAllBySession(Guid idSession)
        {
            return _context.EvaluationCoach.Where(EvaluationCoachSpecs.GetOneBySession(idSession)).ToList();
        }

        public List<EvaluationCoach> GetAllByCoach(Guid idCoach)
        {
            return _context.EvaluationCoach.Where(EvaluationCoachSpecs.GetOneByCoach(idCoach)).ToList();
        }

        public List<EvaluationCoach> GetAllByCoachAndSession(Guid idCoach, Guid idSession)
        {
            return _context.EvaluationCoach.Where(x => x.IdCoach == idCoach && x.IdSession == idSession).ToList();
        }

        public void Update(EvaluationCoach Evaluation)
        {
            _context.Entry<EvaluationCoach>(Evaluation).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
