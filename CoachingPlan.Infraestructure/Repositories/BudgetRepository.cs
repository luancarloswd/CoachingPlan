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
    public class BudgetRepository : IBudgetRepository
    {
        AppDataContext _context;
        public BudgetRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Budget Budget)
        {
            _context.Budget.Add(Budget);
        }

        public void Delete(Budget Budget)
        {
            _context.Budget.Remove(Budget);
        }

        public List<Budget> GetAll()
        {
            return _context.Budget.Include(x => x.CoachingProcess).ToList();
        }

        public List<Budget> GetAll(int take, int skip)
        {
            return _context.Budget.OrderBy(x => x.ProposalDate).Skip(skip).Take(take).ToList();
        }

        public Budget GetOne(Guid id)
        {
            return _context.Budget.Where(BudgetSpecs.GetOne(id)).Include(x => x.CoachingProcess).FirstOrDefault();
        }

        public List<Budget> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _context.Budget.Where(x => x.CoachingProcess.Id == idCoachingProcess).ToList();
        }
        public Budget GetOneIncludeCoachingProcess(Guid id)
        {
            return _context.Budget.Include(x => x.CoachingProcess).FirstOrDefault(x => x.Id == id);
        }
        public void Update(Budget Budget)
        {
            _context.Entry<Budget>(Budget).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
