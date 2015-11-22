using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class CoachingProcessRepository : ICoachingProcessRepository
    {
        AppDataContext _context;
        public CoachingProcessRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(CoachingProcess coachingProcess)
        {
            _context.CoachingProcess.Add(coachingProcess);
        }

        public void Delete(CoachingProcess coachingProcess)
        {
            _context.CoachingProcess.Remove(coachingProcess);
        }

        public List<CoachingProcess> GetAll()
        {
            return _context.CoachingProcess.ToList();
        }

        public CoachingProcess GetOneIncludeDetails(Guid id)
        {
            return _context.CoachingProcess.Include(x => x.Coachee.Select(n => n.User.Person)).Include(x => x.Coach.Select(n => n.User.Person)).Include(x => x.PerformanceIndicator).Include(x => x.Budget).Include(x => x.Service).Include(x => x.ActionPlan.Objective.Select(y =>y.Mark.Select(z => z.Job))).Include(x => x.Budget).Include(x => x.FilledToolCoach.Select(n => n.EvaluationTool)).Include(x => x.FilledToolCoachee.Select(n => n.EvaluationTool)).FirstOrDefault(x => x.Id == id);
        }

        public List<CoachingProcess> GetAll(int take, int skip)
        {
            return _context.CoachingProcess.OrderBy(x => x.StartDate).Skip(skip).Take(take).ToList();
        }

        public CoachingProcess GetOne(Guid id)
        {
            return _context.CoachingProcess.Where(CoachingProcessSpecs.GetOne(id)).FirstOrDefault();
        }

        public List<CoachingProcess> GetAllByService(Guid idService)
        {
            return _context.CoachingProcess.Where(x => x.Service.FirstOrDefault(y => y.Id == idService).Id == idService).ToList();
        }

        public List<CoachingProcess> GetAllByCoachee(string idCoachee)
        {
            return _context.CoachingProcess.Where(x => x.Coachee.FirstOrDefault(y => y.IdUser == idCoachee).IdUser == idCoachee).ToList();
        }

        public void Update(CoachingProcess coachingProcess)
        {
            _context.Entry<CoachingProcess>(coachingProcess).State = System.Data.Entity.EntityState.Modified;
        }
        public CoachingProcess UtilizationCoachingProcess(Guid id)
        {
           var process = _context.CoachingProcess.Include(x => x.Session.Select(n => n.EvaluationCoachee.Select(z => z.Coachee.User.Person))).FirstOrDefault(x => x.Id == id);
           var process2 = _context.CoachingProcess.Include(x => x.Session.Select(n => n.EvaluationCoach.Select(z => z.Coach.User.Person))).FirstOrDefault(x => x.Id == id);
            foreach(var session in process.Session)
            {
                foreach(var eval in process2.Session.FirstOrDefault(x=> x.Id == session.Id).EvaluationCoach)
                    session.EvaluationCoach.Add(eval);
            }
            return process;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
