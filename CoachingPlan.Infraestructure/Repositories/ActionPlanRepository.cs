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
    public class ActionPlanRepository : IActionPlanRepository
    {
        AppDataContext _context;
        public ActionPlanRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(ActionPlan ActionPlan)
        {
            _context.ActionPlan.Add(ActionPlan);
        }

        public void Delete(ActionPlan ActionPlan)
        {
            _context.ActionPlan.Remove(ActionPlan);
        }

        public List<ActionPlan> GetAll()
        {
            return _context.ActionPlan.ToList();
        }

        public List<ActionPlan> GetAll(int take, int skip)
        {
            return _context.ActionPlan.OrderBy(x => x.Description).Skip(skip).Take(take).ToList();
        }

        public ActionPlan GetOne(Guid id)
        {
            return _context.ActionPlan.Where(ActionPlanSpecs.GetOne(id)).Include(x => x.CoachingProcess).Include(x => x.Objective).Include(x => x.Objective.Select(y => y.Mark)).Include(x => x.Objective.Select(y => y.Mark.Select(z => z.Job))).FirstOrDefault();
        }

        public ActionPlan GetOneIncludeObjective(Guid id)
        {
            return _context.ActionPlan.Where(ActionPlanSpecs.GetOne(id)).Include(x => x.Objective).FirstOrDefault();
        }

        public List<ActionPlan> GetAllByCoacingProcess(Guid idCoachingProcess)
        {
            return _context.ActionPlan.Where(x => x.CoachingProcess.FirstOrDefault(y => y.Id == idCoachingProcess).Id == idCoachingProcess).ToList();
        }
        public ActionPlan GetOneIncludeCoachingProcess(Guid id)
        {
            return _context.ActionPlan.Include(x => x.CoachingProcess).FirstOrDefault(x => x.Id == id);
        }
        public void Update(ActionPlan ActionPlan)
        {
            _context.Entry<ActionPlan>(ActionPlan).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
